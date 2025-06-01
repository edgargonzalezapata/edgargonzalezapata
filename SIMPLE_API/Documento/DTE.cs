using ChileSystems.DTE.Engine.XML;
using SIMPLE_API.Documento;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using SIMPLE_API.Security.Firma;
using System.Globalization;

namespace ChileSystems.DTE.Engine.Documento
{
    [XmlRoot("DTE", Namespace = "")]
    public class DTE
    {
        private string DTERelativeFilePath { get; set; }
        public string DTEfilepath { get { return AppDomain.CurrentDomain.BaseDirectory + DTERelativeFilePath; } }

        [XmlAttribute("version")]
        public string Version { get { return Engine.Config.Resources.versionDTE; } set { } }

        [XmlElement("Documento")]
        public Documento Documento { get; set; }
        public bool ShouldSerializeDocumento() { return !string.IsNullOrEmpty(Documento.Id); }

        [XmlElement("Exportaciones")]
        public Exportaciones Exportaciones { get; set; }
        public bool ShouldSerializeExportaciones() { return !string.IsNullOrEmpty(Exportaciones.Id); }

        //public override string ToString() {
        //    return File.ReadAllText(DTEfilepath);
        //}

        public override string ToString()
        {
            if (string.IsNullOrEmpty(DTEfilepath)) {
                string filepath = "";
                string xmlContent = XmlHandler.Serialize<DTE>(this, SerializationType.SerializationTypes.LineBreakNoIndent, out filepath);
                this.DTERelativeFilePath = filepath;
                return xmlContent;
            }
            return File.ReadAllText(DTEfilepath, Encoding.GetEncoding("ISO-8859-1"));
        }

        public string ToDisk(string path)
        {
            string filePath = "";
            XmlHandler.Serialize<DTE>(this, SerializationType.SerializationTypes.LineBreakNoIndent, out filePath, true, false, null, path);
            return filePath;
        }

        public DTE()
        {
            Documento = new Documento();
            Exportaciones = new Exportaciones();
        }

        public string Firmar(DateTime fechaHora,string nombreCertificado, out string message, string outputDirectory = "out\\temp\\", string customName = "", string password = "")
        {
            Documento.FechaHoraFirma =  fechaHora;
            string filePath = "";
            message = "";
            try
            {
                string xmlContent = XmlHandler.Serialize<DTE>(this, SerializationType.SerializationTypes.LineBreakNoIndent, out filePath, true, false, null, outputDirectory, true, "", customName);
                string newContentSigned = SIMPLE_API.Security.Firma.Firma.FirmarDocumentoContent(filePath, this.Documento.Id, nombreCertificado, xmlContent, password);
                this.DTERelativeFilePath = filePath;
                
            }
            catch (Exception ex)
            {
                filePath = ex.Message + ex.StackTrace;
                message = ex.Message + ex.StackTrace;
            }
            return filePath;
        }
        
        public string Firmar(X509Certificate2 certificado, out string message)
        {
            var xmlStringFirmado = "";
            Documento.FechaHoraFirma = DateTime.Now;
            message = "";
            try
            {
                var xmlContent = XmlHandler.SerializeNoFile(this, SerializationType.SerializationTypes.LineBreakNoIndent, out message, true, null);
                var (firmaExitosa, xml) = xmlContent.FirmarXml(Documento.Id, certificado);
                if (firmaExitosa)
                    xmlStringFirmado = xml;
                return xmlStringFirmado;
            }
            catch (Exception ex)
            {
                message = ex.StackTrace;
                return message;
            }
        }

        public string FirmarExportacion(string nombreCertificado, out string message, string outputDirectory = "out\\temp\\", string customName = "", string password = "")
        {
            message = "";
            Exportaciones.FechaHoraFirma = DateTime.Now;
            string filePath = "";
            try
            {
                string xmlContent = XmlHandler.Serialize<DTE>(this, SerializationType.SerializationTypes.LineBreakNoIndent, out filePath, true, false, null, outputDirectory, true, "", customName);
                var content = SIMPLE_API.Security.Firma.Firma.FirmarDocumentoContent(filePath, this.Exportaciones.Id, nombreCertificado, xmlContent, password);
                this.DTERelativeFilePath = filePath;
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
