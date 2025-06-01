using ChileSystems.DTE.Engine.Documento;
using ChileSystems.DTE.Engine.XML;
using SIMPLE_API.Security.Firma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChileSystems.DTE.Engine.RCOF
{
    [XmlRoot("ConsumoFolios")]
    public class ConsumoFolios
    {
        [XmlAttribute("version")]
        public string Version { get { return Engine.Config.Resources.versionRCOF; } set { } }

        [XmlAttribute("schemaLocation", Namespace = XmlSchema.InstanceNamespace)]
        public string xsiSchemaLocation = "http://www.sii.cl/SiiDte ConsumoFolio_v10.xsd";

        [XmlElement("DocumentoConsumoFolios")]
        public DocumentoConsumoFolios DocumentoConsumoFolios { get; set; }

        public ConsumoFolios()
        {
            DocumentoConsumoFolios = new DocumentoConsumoFolios();
        }

        public string Firmar(string nombreCertificado, out string xml, string outputDirectory = "out\\temp\\", string customName = "", string password = "")
        {
            string filePath = "";
            List<string> namespaces = new List<string>();
            namespaces.Add("xsi&http://www.w3.org/2001/XMLSchema-instance");
            string xmlContent = XmlHandler.Serialize<ConsumoFolios>(this, SerializationType.SerializationTypes.LineBreakNoIndent, out filePath, true, false, namespaces, outputDirectory, true, "", customName);
            if (string.IsNullOrEmpty(filePath)) throw new Exception(xmlContent);
            
            xml = SIMPLE_API.Security.Firma.Firma.FirmarDocumentoContent(filePath, DocumentoConsumoFolios.Id, nombreCertificado, xmlContent, password);
            return filePath;
        }

        public string Firmar(X509Certificate2 certificado, out string message)
        {
            var xmlStringFirmado = "";
            List<string> namespaces = new List<string>();
            namespaces.Add("xsi&http://www.w3.org/2001/XMLSchema-instance");

            var xmlContent = XmlHandler.SerializeNoFile(this, SerializationType.SerializationTypes.LineBreakNoIndent, out message, true, namespaces);
            var (firmaExitosa, xml) = xmlContent.FirmarXml(DocumentoConsumoFolios.Id, certificado);
            if (firmaExitosa)
                xmlStringFirmado = xml;
            return xmlStringFirmado;
        }

    }
}
