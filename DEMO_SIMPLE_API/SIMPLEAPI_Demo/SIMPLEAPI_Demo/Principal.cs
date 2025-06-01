using SIMPLEAPI_Demo.Clases;
using SIMPLEAPI_Demo.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChileSystems.DTE.Engine.Enum;
using SIMPLEAPI_Demo.Vista;
using static SIMPLE_API.Enum.Ambiente;
// using iTextSharp.text.pdf.parser;


namespace SIMPLEAPI_Demo
{
   
    public partial class Principal : Form
    {
        Handler handler = new Handler();
        Configuracion configuracion = new Configuracion();
        List<ItemBoleta> items;
        public Principal()
        {
            InitializeComponent();
            items = new List<ItemBoleta>();
            this.configuracion = new Configuracion();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema formulario = new ConfiguracionSistema();
            formulario.ShowDialog();
            handler.configuracion.LeerArchivo();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] pathFiles = openFileDialog1.FileNames;
                List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
                List<string> xmlDtes = new List<string>();
                int sobreCount = 1;
                int dteCount = 0;
                string folderPath = System.IO.Path.Combine("out\\temp\\", DateTime.Now.ToString("yyyy-MM"));
                Directory.CreateDirectory(folderPath);

                // Crear listas temporales para acumular 500 DTEs
                List<ChileSystems.DTE.Engine.Documento.DTE> dtesTemp = new List<ChileSystems.DTE.Engine.Documento.DTE>();
                List<string> xmlDtesTemp = new List<string>();

                foreach (string pathFile in pathFiles)
                {
                    string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
                    var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);
                    
                    dtesTemp.Add(dte);
                    xmlDtesTemp.Add(xml);
                    dteCount++;

                    // Cuando llegamos a 500 DTEs o es el último archivo
                    if (dtesTemp.Count == 500 || dteCount == pathFiles.Length)
                    {
                        try
                        {
                            var EnvioSII = handler.GenerarEnvioBoletaDTEToSII(dtesTemp, xmlDtesTemp);
                            var sobrePath = EnvioSII.Firmar(configuracion.Certificado.Nombre);

                            handler.Validate(sobrePath, SIMPLE_API.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta);
                            
                            // Guardar el sobre con nombre que indica cantidad de DTEs
                            string destinationFile = Path.Combine(folderPath, $"EnvioBoleta_{sobreCount}_{dtesTemp.Count}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml");
                            File.Move(sobrePath, destinationFile);
                            
                            Console.WriteLine($"Sobre {sobreCount} generado con {dtesTemp.Count} DTEs");
                            
                            // Limpiar las listas temporales
                            dtesTemp.Clear();
                            xmlDtesTemp.Clear();
                            sobreCount++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al generar sobre {sobreCount}: {ex.Message}");
                        }
                    }
                }

                MessageBox.Show($"Proceso completado. Se generaron {sobreCount-1} sobres de envío con {dteCount} DTEs en total.\nLos sobres se encuentran en: {folderPath}");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            generarDTEboletas fomr = new generarDTEboletas();
            fomr.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            if (!configuracion.VerificarCarpetasIniciales())
            {
                //Los ejemplos de este proyecto se basan en estas dos carpetas. Se pueden modificar a gusto pero son necesarias al inicio.
                //Para más información: https://www.simple-api.cl/Tutoriales/Instalacion (Estructura de carpetas)
                MessageBox.Show("Se deben agregar las carpetas iniciales out\\temp, out\\caf y XML", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            configuracion.LeerArchivo();
            handler.configuracion = configuracion;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            generarDTE_NCE fomr = new generarDTE_NCE();
            fomr.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validador formulario = new Validador();
            formulario.ShowDialog();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            /*Este botón no sirve si estás certificando un RUT, para ello, se debe usar el evento click del botón "botonEnviarSii". 
            * Puedes usar este botón para probar la API REST del SII para enviar tus boletas antes de pasar a producción, no sirve para certificar.*/
            openFileDialog1.Multiselect = false;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string pathFile = openFileDialog1.FileName;
                long trackId = handler.EnviarEnvioDTEToSII(pathFile, radioProduccion.Checked ? AmbienteEnum.Produccion : AmbienteEnum.Certificacion, out string messageResult, true);
                if (!string.IsNullOrEmpty(messageResult)) MessageBox.Show("Ocurrió un error: " + messageResult);
                else MessageBox.Show("Sobre enviado correctamente. TrackID: " + trackId.ToString());
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Main fomr = new Main();
            fomr.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string pathFile = openFileDialog1.FileName;
                long trackId = handler.EnviarEnvioDTEToSII(pathFile, radioProduccion.Checked ? AmbienteEnum.Produccion : AmbienteEnum.Certificacion, out string messageResult, true);
                if (!string.IsNullOrEmpty(messageResult)) MessageBox.Show("Ocurrió un error: " + messageResult);
                else MessageBox.Show("Sobre enviado correctamente. TrackID: " + trackId.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SobreEnvioGenerator generator = new SobreEnvioGenerator();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurar propiedades del cuadro de diálogo
                openFileDialog.Title = "Seleccionar archivo";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

                // Mostrar el cuadro de diálogo y esperar a que el usuario seleccione un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado
                    string rutaArchivo = openFileDialog.FileName;
                    var dir = Directory.CreateDirectory("out\\temp\\");

                    // Hacer algo con la ruta del archivo (por ejemplo, mostrarla en un TextBox)
                    generator.InsertarNotaCreditoEnSobreDeEnvio(rutaArchivo, "out\\temp\\" + DateTime.Now.Year);


                }
            }

        }
    }
}
