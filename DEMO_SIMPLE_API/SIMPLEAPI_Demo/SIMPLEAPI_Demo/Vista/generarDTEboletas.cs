using SIMPLEAPI_Demo.Controller;
using ChileSystems.DTE.Engine.Enum;
using SIMPLEAPI_Demo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace SIMPLEAPI_Demo.Vista
{
    public partial class generarDTEboletas : Form
    {
        encabezadoBoletaController objencabezadoBoletaController = new encabezadoBoletaController();
        Handler handler = new Handler();
        List<ItemBoleta> items;
        decimal total;

        public string sql;
        public OleDbDataAdapter objadapter;
        public DataSet objdataset;

        ItemBoletaController ItemBoletaController = new ItemBoletaController();
        public generarDTEboletas()
        {
            InitializeComponent();
            items = new List<ItemBoleta>();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DateTime inicio = txtInicio.Value.Date;
            DateTime termino = txtTermino.Value.Date;

            // TODO: esta línea de código carga datos en la tabla 'ventasFandaDataSet.caja' Puede moverla o quitarla según sea necesario.
            this.boletasTableAdapter.Fill(this.ventasFandaDataSet.boletas, inicio, termino);

            double  neto = 0;
            double iva = 0;
            double bruto = 0;


            foreach (DataGridViewRow row in grilla1.Rows)
            {

                neto += Convert.ToDouble(row.Cells[3].Value);
                iva += Convert.ToDouble(row.Cells[4].Value);
                bruto += Convert.ToDouble(row.Cells[5].Value);

            }


            lbNeto.Text = neto.ToString("N");
            lbIVA.Text = iva.ToString("N");
            lbBruto.Text = bruto.ToString("N");
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            int folio;
            int fk_venta;
            DateTime FechaEmision;

            int dteCount = 0;
            string folderPath = "";
            
            // Listas para almacenar los DTEs y XMLs para el sobre
            List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
            List<string> xmlDtes = new List<string>();
            int sobreCount = 1;

            foreach (DataGridViewRow row in grilla1.Rows)
            {
                fk_venta = Convert.ToInt32(row.Cells[0].Value);
                FechaEmision = Convert.ToDateTime(row.Cells[1].Value);
                folio = Convert.ToInt32(row.Cells[2].Value);

                GetItem(ref fk_venta);

                var dte = handler.GenerateDTEsibb(ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica, FechaEmision, (int)folio);
                handler.GenerateDetails(dte, items);
                string casoPrueba = "CASO-" + folio.ToString("N0");
                handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.BoletaElectronica, null, 0, casoPrueba);
                var path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", out string messageOut);
                handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);

                // Crear carpeta si no existe
                if (string.IsNullOrEmpty(folderPath))
                {
                    folderPath = Path.Combine("out\\temp\\", FechaEmision.ToString("yyyy-MM"));
                    Directory.CreateDirectory(folderPath);
                }

                // Leer el XML del DTE y agregarlo a las listas
                string xml = File.ReadAllText(path, Encoding.GetEncoding("ISO-8859-1"));
                dtes.Add(dte);
                xmlDtes.Add(xml);

                // Mover el DTE individual a la carpeta
                string sourceFile = path;
                FileInfo fi = new FileInfo(sourceFile);
                string dteDestinationFile = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(fi.Name) + "_" + fi.Extension);
                File.Move(sourceFile, dteDestinationFile);

                items.Clear();
                dteCount++;

                // Cuando llegamos a 500 DTEs exactos o es el último DTE y tenemos DTEs pendientes
                if (dtes.Count == 500 || (dteCount == grilla1.Rows.Count && dtes.Count > 0))
                {
                    var EnvioSII = handler.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes);
                    var sobrePath = EnvioSII.Firmar(handler.configuracion.Certificado.Nombre);

                    // Validar y mover el sobre
                    handler.Validate(sobrePath, SIMPLE_API.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta);
                    string destinationFile = Path.Combine(folderPath, $"EnvioBoleta_{sobreCount}_{dtes.Count}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml");
                    File.Move(sobrePath, destinationFile);

                    Console.WriteLine($"Sobre {sobreCount} generado con {dtes.Count} DTEs");

                    // Limpiar las listas para el siguiente sobre
                    dtes.Clear();
                    xmlDtes.Clear();
                    sobreCount++;
                }
            }

            MessageBox.Show($"Proceso completado. Se generaron {sobreCount-1} sobres de envío con {dteCount} DTEs en total.");
        }


        private void generarDTEboletas_Load(object sender, EventArgs e)
        {
            grilla1.AutoGenerateColumns = false;
            handler.configuracion = new Configuracion();
            handler.configuracion.LeerArchivo();
        }
       
        public bool GetItem(ref int fk_venta)
        {
            variablesGlobales objvariablesGlobales = new variablesGlobales();
            try
            {
                if (objvariablesGlobales.ConectaBase())
                {
                    sql = "select p.Descripción,d.cantidad , '1' as Afecto, d.valor , round(d.valor * d.cantidad,0) as Total from d_venta as d inner join lista_costo as p on d.fk_prod = p.id where d.fk_venta = " + fk_venta + "";
                    objadapter = new OleDbDataAdapter(sql, objvariablesGlobales.Conecta);
                    objdataset = new DataSet();
                    objadapter.Fill(objdataset);

                                  
                    String nombre;

                    Console.WriteLine("idVenta: " + fk_venta);
                    foreach (DataRow dr in objdataset.Tables[0].Rows)
                    {
                        ItemBoleta item = new ItemBoleta();

                        // item.Nombre = dr[0].ToString();
                        nombre = dr[0].ToString();
                        if (nombre.Length > 20)
                        {
                            item.Nombre = nombre.Substring(0,20);
                        }
                        else {
                            item.Nombre = dr[0].ToString();
                        }
                        item.Cantidad = Convert.ToDecimal(dr[1].ToString());
                        item.Afecto = true;
                        item.Precio = (int)dr[3];
                        items.Add(item);


                        Console.WriteLine(item.Nombre +"  cantidad : "+  item.Cantidad + "  precio : "+ item.Precio);
                        total = total + (decimal)item.Cantidad * (int)item.Precio;
                        

                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            return false;
        }
    }
  
}

