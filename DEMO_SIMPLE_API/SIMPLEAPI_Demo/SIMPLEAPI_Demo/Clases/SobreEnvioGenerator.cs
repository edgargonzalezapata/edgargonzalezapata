using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

public class SobreEnvioGenerator
{
    public void InsertarNotaCreditoEnSobreDeEnvio(string rutaNotaCredito, string rutaSobreEnvio)
    {
        try
        {
            // Cargar el archivo XML de la nota de crédito
            XmlDocument notaCredito = new XmlDocument();
            notaCredito.Load(rutaNotaCredito);

            // Cargar el archivo XML del sobre de envío
            XmlDocument sobreEnvio = new XmlDocument();
            sobreEnvio.Load(rutaSobreEnvio);

            // Obtener el nodo DTE dentro del sobre de envío
            XmlNode dteNode = sobreEnvio.SelectSingleNode("//DTE");

            // Importar el nodo de la nota de crédito al sobre de envío
            XmlNode notaCreditoNode = sobreEnvio.ImportNode(notaCredito.DocumentElement, true);
            dteNode.AppendChild(notaCreditoNode);

            // Guardar el sobre de envío con la nota de crédito
            sobreEnvio.Save(rutaSobreEnvio);
            MessageBox.Show("La nota de crédito ha sido insertada en el sobre de envío con éxito : " + rutaSobreEnvio);
            Console.WriteLine("La nota de crédito ha sido insertada en el sobre de envío con éxito.");
        }
        catch (Exception ex)
        {
            MessageBox.Show( ex.Message);
            Console.WriteLine("Error al insertar la nota de crédito en el sobre de envío: " + ex.Message);
        }
    }


}
