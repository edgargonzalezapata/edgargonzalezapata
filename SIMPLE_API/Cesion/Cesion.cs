using ChileSystems.DTE.Engine.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SIMPLE_API.Cesion
{
    [XmlRoot("Cesion")]
    public class Cesion
    {
        [XmlAttribute("version")]
        public string Version { get { return "1.0"; } set { } }

        [XmlElement("DocumentoCesion")]
        public DocumentoCesion DocumentoCesion;

        //public string signedXML { get; set; }

        public Cesion(ChileSystems.DTE.Engine.Documento.DTE dte, int secuencia)
        {
            DocumentoCesion = new DocumentoCesion(dte, secuencia);
        }

        public Cesion()
        {

        }

        public string Firmar(string nombreCertificado, out string message, string outputDirectory = "out\\temp\\", string password = "")
        {
            message = "";
            string filePath = "";
            try
            {
                string xmlContent = XmlHandler.Serialize<Cesion>(this, SerializationType.SerializationTypes.LineBreakNoIndent, out filePath, true, false, null, outputDirectory, true, "http://www.sii.cl/SiiDte");
                //AppendXML(filePath);
                var content = SIMPLE_API.Security.Firma.Firma.FirmarDocumentoPath(filePath, this.DocumentoCesion.ID, nombreCertificado, password);
            }
            catch (Exception ex)
            {
                filePath = ex.Message;
                message = ex.StackTrace;
            }
            return filePath;
        }

    }
}
