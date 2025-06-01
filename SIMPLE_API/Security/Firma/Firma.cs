using SIMPLE_API.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SIMPLE_API.Security.Firma
{
    public static class Firma
    {
        public enum TipoXML : int
        {
            NotSet = -1,
            Envio = 0,
            DTE = 1,
            LCV = 2,
            Resultado = 3,
            RCOF = 4,
            LibroBoletas = 5,
            EnvioBoleta = 6,
            LibroGuias = 7,
            AEC = 8
        }

        /// <summary>
        /// Obtiene el certificado con el cual se firmarán los documentos.
        /// El nombre del certificado debe estar configurado en: 
        /// </summary>
        /// <returns>Certificado con el cual se van a firmar los documentos.</returns>
        private static X509Certificate2 ObtenerCertificado(string nombreCertificado, string password = "")
        {
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection = store.Certificates;
            X509Certificate2 cert = null;

            foreach (X509Certificate2 c in certCollection)
            {
                if (c.FriendlyName.Equals(nombreCertificado))
                {
                    cert = c;
                    return cert;
                }
            }

            X509Store store2 = new X509Store(StoreLocation.LocalMachine);
            store2.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection2 = store2.Certificates;

            foreach (X509Certificate2 c in certCollection2)
            {
                if (c.FriendlyName.Equals(nombreCertificado))
                {
                    cert = c;
                    return cert;
                }
            }

            /*Intenta obtener el certificado desde un archivo y password*/
            if (cert == null && !string.IsNullOrEmpty(password))
            {
                //X509Certificate2Collection certCollection3 = new X509Certificate2Collection();
                //certCollection3.Import(nombreCertificado, password, X509KeyStorageFlags.PersistKeySet);
                //cert = certCollection3[0];
                cert = new X509Certificate2(nombreCertificado, password, X509KeyStorageFlags.MachineKeySet |
                   X509KeyStorageFlags.PersistKeySet |
                   X509KeyStorageFlags.Exportable);
            }

            return cert;
        }

        /// <summary>
        /// Firma el XML que se enviará al servicio GetToken del SII.
        /// </summary>
        /// <param name="seed">Valor de la semilla, obtenida de la función ParseSeed.</param>
        /// <returns>String XML que representa la semilla firmada.</returns>
        public static string firmarDocumentoSemilla(string seed, string nombreCertificado, string password = "")
        {
            X509Certificate2 certificado = ObtenerCertificado(nombreCertificado, password);
            try
            {
                if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);
            }
            catch (Exception ex)
            {
                using (certificado.GetRSAPrivateKey()) { } // pure black magic
                try
                {
                    if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);

                }
                catch
                {
                    throw new Exception("No tiene llave privada: " + ex.Message + certificado.ToString(true));
                }

            }

            ////
            //// Cree un nuevo documento xml y defina sus caracteristicas
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(seed);

            ////
            //// Cree el objeto XMLSignature.
            SignedXml signedXml = new SignedXml(doc);

            ////
            //// Agregue la clave privada al objeto xmlSignature.
            signedXml.SigningKey = certificado.PrivateKey;

            ////
            //// Obtenga el objeto signature desde el objeto SignedXml.
            Signature XMLSignature = signedXml.Signature;

            ////
            //// Cree una referencia al documento que va a firmarse
            //// si la referencia es "" se firmara todo el documento
            Reference reference = new Reference("");

            ////
            //// Representa la transformación de firma con doble cifrado para una firma XML  digital que define W3C.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            ////
            //// Agregue el objeto referenciado al obeto firma.
            XMLSignature.SignedInfo.AddReference(reference);

            ////
            //// Agregue RSAKeyValue KeyInfo  ( requerido para el SII ).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));

            ////
            //// Agregar información del certificado x509
            keyInfo.AddClause(new KeyInfoX509Data(certificado));

            //// 
            //// Agregar KeyInfo al objeto Signature 
            XMLSignature.KeyInfo = keyInfo;

            ////
            //// Cree la firma
            signedXml.ComputeSignature();

            ////
            //// Recupere la representacion xml de la firma
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            ////
            //// Agregue la representacion xml de la firma al documento xml
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            ////
            //// Limpie el documento xml de la declaracion xml ( Opcional, pera para nuestro proceso es valido  )
            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            ////
            //// Regrese el valor de retorno
            return doc.InnerXml;
        }

        /// <summary>
        /// Firma digitalmente un documento, con un certificado digital, dada la referencia entregada por parámetro.
        /// </summary>
        /// <param name="filePath">Ruta al archivo que se desea firmar.</param>
        /// <param name="referenceID">Referencia al elemento xml raiz que se desea firmar.</param>
        /// <returns>String XML que representa el archivo firmado digitalmente.</returns>
        public static string FirmarDocumentoPath(string filePath, string referenceID, string nombreCertificado, string password = "")
        {
            var certificado = ObtenerCertificado(nombreCertificado, password);
            try
            {
                if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);
            }
            catch (Exception ex)
            {
                using (certificado.GetRSAPrivateKey()) { } // pure black magic
                try
                {
                    if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);

                }
                catch
                {
                    throw new Exception("No tiene llave privada: " + ex.Message + certificado.ToString(true));
                }

            }


            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(filePath);
           

            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = certificado.PrivateKey;
            Signature XMLSignature = signedXml.Signature;
            Reference reference = new Reference();
            reference.Uri = "#" + referenceID;

            XmlDsigC14NTransform t = new XmlDsigC14NTransform();
            reference.AddTransform(t);            

            XMLSignature.SignedInfo.AddReference(reference);
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));
            keyInfo.AddClause(new KeyInfoX509Data(certificado));
            XMLSignature.KeyInfo = keyInfo;
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
            doc.Save(filePath);

            return doc.InnerXml;
        }

        public static string FirmarDocumentoContent(string pathResult, string referenceID, string nombreCertificado, string content, string password = "")
        {

            var certificado = ObtenerCertificado(nombreCertificado, password);
            try
            {
                if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);
            }
            catch (Exception ex)
            {
                using (certificado.GetRSAPrivateKey()) { } // pure black magic
                try
                {
                    if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);

                }
                catch
                {
                    throw new Exception("No tiene llave privada: " + ex.Message + certificado.ToString(true));
                }

            }

            //byte[] encodedString = Encoding.UTF8.GetBytes(content);

            //// Put the byte array into a stream and rewind it to the beginning
            //MemoryStream ms = new MemoryStream(encodedString);
            //ms.Flush();
            //ms.Position = 0;

            //// Build the XmlDocument from the MemorySteam of UTF-8 encoded bytes
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(ms);


            try {
                if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);

            }
            catch (Exception ex) 
            {
                using (certificado.GetRSAPrivateKey()) { } // pure black magic
                try
                {
                    if (certificado.PrivateKey == null) return "No tiene llave privada: " + certificado.ToString(true);

                }
                catch{
                    throw new Exception("No tiene llave privada: " + ex.Message + certificado.ToString(true));
                }
              
            }

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(content);

            //var node = doc.SelectSingleNode("DTE/Documento/TED/DD/CAF/DA/RS");
            //node.InnerText = ChileSystems.DTE.Engine.Utilidades.EncodeToISO88581(node.InnerText);

            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = certificado.PrivateKey == null ? certificado.GetRSAPrivateKey() : certificado.PrivateKey;
            Signature XMLSignature = signedXml.Signature;
            XMLSignature.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            Reference reference = new Reference();
            reference.Uri = "#" + referenceID;
            reference.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";

            XmlDsigC14NTransform t = new XmlDsigC14NTransform();
            reference.AddTransform(t);

            XMLSignature.SignedInfo.AddReference(reference);
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));
            keyInfo.AddClause(new KeyInfoX509Data(certificado));
            XMLSignature.KeyInfo = keyInfo;
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            //using (TextWriter sw = new StreamWriter(pathResult, false, Encoding.UTF8)) //Set encoding
            //{
            //    doc.Save(sw);
            //}
            doc.Save(pathResult);

            return doc.InnerXml;
        }

        //public class EscapeQuotesXmlWriter : XmlWrappingWriter
        //{
        //    public EscapeQuotesXmlWriter(XmlWriter baseWriter) : base(baseWriter)
        //    {
        //    }

        //    public override void WriteString(string text)
        //    {
        //        foreach (char ch in text)
        //        {
        //            if (ch == '"')
        //            {
        //                WriteEntityRef("quot");
        //            }
        //            else if (ch == '\'')
        //            {
        //                WriteEntityRef("apos");
        //            }
        //            else
        //            {
        //                base.WriteString(ch.ToString());
        //            }
        //        }
        //    }
        //    public override void WriteChars(char[] buffer, int index, int count)
        //    {
        //        WriteString(new String(buffer.Where((ch, pos) => pos >= index && pos < index + count).ToArray()));
        //    }

        //}

        public static string FirmarDocumentoLibro(string filePath, string referenceID, string nombreCertificado, string password = "")
        {
            var certificado = ObtenerCertificado(nombreCertificado, password);

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(filePath);
            
            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = certificado.PrivateKey;
            Signature XMLSignature = signedXml.Signature;
            Reference reference = new Reference();
            reference.Uri = "#" + referenceID;

            XmlDsigC14NTransform t = new XmlDsigC14NTransform();
            reference.AddTransform(t);


            XMLSignature.SignedInfo.AddReference(reference);
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));
            keyInfo.AddClause(new KeyInfoX509Data(certificado));
            XMLSignature.KeyInfo = keyInfo;
            signedXml.ComputeSignature();


            XmlElement xmlDigitalSignature = signedXml.GetXml();
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
            
            doc.Save(filePath);

            return doc.InnerXml;
        }
        /// <summary>
        /// Ruta al módulo de una llave RSA de un documento con estructura XML LCV.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_MODULUS_RESULT = "sii:Resultado/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        /// <summary>
        /// Ruta al exponente de una llave RSA de un documento con estructura XML LCV.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_EXPONENT_RESULT = "sii:Resultado/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        /// <summary>
        /// Ruta al módulo de una llave RSA de un documento con estructura XML LCV.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_MODULUS_LCV = "sii:LibroCompraVenta/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        /// <summary>
        /// Ruta al exponente de una llave RSA de un documento con estructura XML LCV.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_EXPONENT_LCV = "sii:LibroCompraVenta/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        /// <summary>
        /// Ruta al módulo de una llave RSA de un documento con estructura XML DTE.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_MODULUS = "sii:DTE/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        /// <summary>
        /// Ruta al exponente de una llave RSA de un documento con estructura XML DTE.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_EXPONENT = "sii:DTE/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        /// <summary>
        /// Ruta al módulo de una llave RSA de un documento con estructura XML EnvioDTE.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_MODULUS_ENVIO = "sii:EnvioDTE/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        /// <summary>
        /// Ruta al exponente de una llave RSA de un documento con estructura XML EnvioDTE.
        /// Se usa para verificar la firma válida del documento.
        /// </summary>
        private const string XPATH_EXPONENT_ENVIO = "sii:EnvioDTE/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        private const string XPATH_MODULUS_RCOF = "sii:ConsumoFolios/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        private const string XPATH_EXPONENT_RCOF = "sii:ConsumoFolios/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        private const string XPATH_MODULUS_AEC = "sii:AEC/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        private const string XPATH_EXPONENT_AEC = "sii:AEC/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";
        
        private const string XPATH_MODULUS_LIBROBOLETAS = "sii:LibroBoleta/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        private const string XPATH_EXPONENT_LIBROBOLETAS = "sii:LibroBoleta/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        private const string XPATH_MODULUS_ENVIO_BOLETA = "sii:EnvioBOLETA/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Modulus";

        private const string XPATH_EXPONENT_ENVIO_BOLETA = "sii:EnvioBOLETA/sig:Signature/sig:KeyInfo/sig:KeyValue/sig:RSAKeyValue/sig:Exponent";

        /// <summary>
        /// Verifica la firma de un documento.
        /// </summary>
        /// <param name="filePath">Ruta del archivo, del cual, se desea verificar su firma.</param>
        /// <returns>Retorna verdader si la firma es válida, falso de otra manera.</returns>        
        public static bool VerificarFirma(string filePath, TipoXML tipoXml, out string messageOut)
        //public static bool VerificarFirma(string filePath, bool IsEnvio = true, bool IsDTE = false, bool isLCV = false, bool isResult = false)
        {
            messageOut = string.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.LoadXml(System.IO.File.ReadAllText(filePath, System.Text.Encoding.GetEncoding("ISO-8859-1")));

                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("sii", string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? "http://www.sii.cl/SiiDte" : doc.DocumentElement.NamespaceURI);
                if(tipoXml == TipoXML.LibroBoletas)
                    ns.AddNamespace("sig", "http://www.sii.cl/SiiDte");
                else ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");

                //ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");
                string mod = string.Empty;
                string exp = string.Empty;

                switch (tipoXml)
                {
                    case TipoXML.Envio:
                        mod = doc.SelectSingleNode(XPATH_MODULUS_ENVIO, ns).InnerText;
                        exp = doc.SelectSingleNode(XPATH_EXPONENT_ENVIO, ns).InnerText;
                        break;
                    case TipoXML.EnvioBoleta:
                        mod = doc.SelectSingleNode(XPATH_MODULUS_ENVIO_BOLETA, ns).InnerText;
                        exp = doc.SelectSingleNode(XPATH_EXPONENT_ENVIO_BOLETA, ns).InnerText;
                        break;
                    case TipoXML.DTE:
                       mod = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_MODULUS.Replace("sii:", "") : XPATH_MODULUS, ns).InnerText;
                        exp = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_EXPONENT.Replace("sii:", "") : XPATH_EXPONENT, ns).InnerText;
                        break;                    
                    case TipoXML.LCV:
                        mod = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_MODULUS_LCV.Replace("sii:", "") : XPATH_MODULUS_LCV, ns).InnerText;
                        exp = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_LCV.Replace("sii:", "") : XPATH_EXPONENT_LCV, ns).InnerText;
                        break;
                    case TipoXML.Resultado:
                        mod = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_MODULUS_RESULT.Replace("sii:", "") : XPATH_MODULUS_RESULT, ns).InnerText;
                        exp = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_RESULT.Replace("sii:", "") : XPATH_EXPONENT_RESULT, ns).InnerText;
                        break;
                    case TipoXML.RCOF:
                        mod = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_MODULUS_RCOF.Replace("sii:", "") : XPATH_MODULUS_RCOF, ns).InnerText;
                        exp = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_RCOF.Replace("sii:", "") : XPATH_EXPONENT_RCOF, ns).InnerText;
                        break;
                    case TipoXML.LibroBoletas:
                        mod = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_MODULUS_LIBROBOLETAS.Replace("sii:", "") : XPATH_MODULUS_LIBROBOLETAS, ns).InnerText;
                        exp = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_LIBROBOLETAS.Replace("sii:", "") : XPATH_EXPONENT_LIBROBOLETAS, ns).InnerText;
                        break;
                    case TipoXML.AEC:
                        mod = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_MODULUS_AEC.Replace("sii:", "") : XPATH_MODULUS_AEC, ns).InnerText;
                        exp = doc.SelectSingleNode(string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_AEC.Replace("sii:", "") : XPATH_EXPONENT_AEC, ns).InnerText;
                        break;
                    default:
                        throw new Exception();
                }

                string publicKeyXml = string.Empty;

                publicKeyXml += "<RSAKeyValue>";
                publicKeyXml += "<Modulus>{0}</Modulus>";
                publicKeyXml += "<Exponent>{1}</Exponent>";
                publicKeyXml += "</RSAKeyValue>";

                publicKeyXml = string.Format(publicKeyXml, mod, exp);

                RSACryptoServiceProvider publicKey = new RSACryptoServiceProvider();
                publicKey.FromXmlString(publicKeyXml);

                SignedXml signedXml = new SignedXml(doc);

                XmlNodeList nodeList = doc.GetElementsByTagName("Signature");

                signedXml.LoadXml((XmlElement)nodeList[tipoXml == TipoXML.Envio || tipoXml == TipoXML.EnvioBoleta ? nodeList.Count - 1 : 0]);

                return signedXml.CheckSignature(publicKey);
            }
            catch (Exception ex)
            {
                messageOut = ex.ToString();
                return false;
            }
        }

        private const string XPATH_FIRMA_DTE = "sii:DTE/sig:Signature/sig:SignatureValue";
        public static string GetFirmaFromFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(filePath);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("sii", doc.DocumentElement.NamespaceURI);
            ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");

            return doc.SelectSingleNode(XPATH_FIRMA_DTE, ns).InnerText;
        }

        private const string XPATH_FIRMA_DTE_STRING = "sii:EnvioDTE/sii:SetDTE/sii:DTE/sig:Signature/sig:SignatureValue";
        public static string GetFirmaFromString(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(xml);
            //doc.InnerXml =  doc.InnerXml.Replace(@"xmlns=""""", "").Replace("iso-8859-1", "ISO-8859-1");
            //doc.LoadXml(System.IO.File.ReadAllText(filePath, System.Text.Encoding.GetEncoding("ISO-8859-1")));
            
            try
            {    
                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("sii", "http://www.sii.cl/SiiDte");
                ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");
                /*doc.InnerXml = RemoveAllNamespaces1(doc.InnerXml);

                string texto = doc.SelectNodes(XPATH_FIRMA_DTE_STRING)[0].InnerText;
                string xmlTexto = doc.SelectNodes(XPATH_FIRMA_DTE_STRING)[0].InnerXml;
                return xmlTexto;*/
                return doc.SelectSingleNode(XPATH_FIRMA_DTE_STRING, ns).InnerText;
            }
            catch (Exception ex)
            {
                string efd = ex.Message;
                return ex.Message;
            }
        }

        public static string RemoveAllNamespaces1(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        /// <summary>
        /// Ruta al valor del Digest de la firma digital de un EnvioDTE.
        /// </summary>
        private const string XPATH_DIGEST_ENVIO = "sii:EnvioDTE/sig:Signature/sig:SignedInfo/sig:Reference/sig:DigestValue";
        private const string XPATH_DIGEST_ENVIO2 = "sii:EnvioDTE/sii:SetDTE/sii:DTE/sig:Signature/sig:SignedInfo/sig:Reference/sig:DigestValue";
        public static string GetDigestValueFromFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(filePath);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("sii", doc.DocumentElement.NamespaceURI);
            ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");
            try
            {          
                XmlNode nodo = doc.SelectSingleNode(XPATH_DIGEST_ENVIO, ns);
                string retorno = nodo.InnerText;
                return retorno;
            }
            catch 
            {
                XmlNode nodo = doc.SelectSingleNode(XPATH_DIGEST_ENVIO2, ns);
                string retorno = nodo.InnerText;
                return retorno;
            }
        }

        #region Sobrecargas usando sin depender de archivos en disco
        /// <summary>
        /// Firma el XML que se enviará al servicio GetToken del SII.
        /// </summary>
        /// <param name="seed">Valor de la semilla, obtenida de la función ParseSeed.</param>
        /// <param name="certificado"></param>
        /// <returns>String XML que representa la semilla firmada.</returns>
        public static string FirmarDocumentoSemilla(string seed, X509Certificate2 certificado)
        {
            //// Cree un nuevo documento xml y defina sus caracteristicas
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(seed);

            //// Cree el objeto XMLSignature.
            SignedXml signedXml = new SignedXml(doc);

            //// Agregue la clave privada al objeto xmlSignature.
            signedXml.SigningKey = certificado.PrivateKey;

            //// Obtenga el objeto signature desde el objeto SignedXml.
            Signature xmlSignature = signedXml.Signature;

            //// Cree una referencia al documento que va a firmarse
            //// si la referencia es "" se firmara todo el documento
            Reference reference = new Reference("");

            //// Representa la transformación de firma con doble cifrado para una firma XML  digital que define W3C.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            //// Agregue el objeto referenciado al obeto firma.
            xmlSignature.SignedInfo.AddReference(reference);

            //// Agregue RSAKeyValue KeyInfo  ( requerido para el SII ).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));

            //// Agregar información del certificado x509
            keyInfo.AddClause(new KeyInfoX509Data(certificado));

            //// Agregar KeyInfo al objeto Signature 
            xmlSignature.KeyInfo = keyInfo;

            //// Cree la firma
            signedXml.ComputeSignature();

            //// Recupere la representacion xml de la firma
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            //// Agregue la representacion xml de la firma al documento xml
            doc.DocumentElement?.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            //// Limpie el documento xml de la declaracion xml ( Opcional, pera para nuestro proceso es valido  )
            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }
            //// Regrese el valor de retorno
            return doc.InnerXml;
        }

        /// <summary>
        /// Firma un Xml que se encuentra en formato XmlDocument usando un certificado en formato X509Certificate2
        /// </summary>
        /// <param name="xmlstring"></param>
        /// <param name="referenceId"></param>
        /// <param name="certificado"></param>
        /// <returns></returns>
        public static (bool firmaExitosa, string xmlStringFirmado) FirmarXml(this string xmlstring, string referenceId, X509Certificate2 certificado)
        {
            var document = new XmlDocument() { PreserveWhitespace = true };
            document.LoadXml(xmlstring);
            bool firmaExitosa = false;
            SignedXml signedXml = new SignedXml(document);
            signedXml.SigningKey = certificado.PrivateKey;
            Signature xmlSignature = signedXml.Signature;
            xmlSignature.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            Reference reference = new Reference();
            reference.Uri = "#" + referenceId;
            reference.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";
            XmlDsigC14NTransform t = new XmlDsigC14NTransform();
            reference.AddTransform(t);

            xmlSignature.SignedInfo.AddReference(reference);
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));
            keyInfo.AddClause(new KeyInfoX509Data(certificado));
            xmlSignature.KeyInfo = keyInfo;
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
            if (document.DocumentElement != null)
            {
                document.DocumentElement.AppendChild(document.ImportNode(xmlDigitalSignature, true));
                firmaExitosa = true;
            }
            return (firmaExitosa, document.OuterXml);
        }

        /// <summary>
        /// Verifica la firma de un documento en formato XmlDocument.
        /// </summary>
        /// <param name="document"> documento en formato XML</param>
        /// <param name="tipoXml"> Tipo DTE que se quiere validar</param>
        /// <param name="messageOut"> mensaje de error de validación específico.</param>
        /// <returns>Retorna verdader si la firma es válida, falso de otra manera.</returns>        
        public static bool VerificarFirma(this XmlDocument document, Firma.TipoXML tipoXml, out string messageOut)
        {
            messageOut = string.Empty;
            try
            {
                XmlNamespaceManager ns = new XmlNamespaceManager(document.NameTable);
                ns.AddNamespace("sii", string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? "http://www.sii.cl/SiiDte" : document.DocumentElement.NamespaceURI);
                if(tipoXml == Firma.TipoXML.LibroBoletas)
                    ns.AddNamespace("sig", "http://www.sii.cl/SiiDte");
                else ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");

                //ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");
                string mod = string.Empty;
                string exp = string.Empty;

                switch (tipoXml)
                {
                    case Firma.TipoXML.Envio:
                        mod = document.SelectSingleNode(XPATH_MODULUS_ENVIO, ns).InnerText;
                        exp = document.SelectSingleNode(XPATH_EXPONENT_ENVIO, ns).InnerText;
                        break;
                    case Firma.TipoXML.EnvioBoleta:
                        mod = document.SelectSingleNode(XPATH_MODULUS_ENVIO_BOLETA, ns).InnerText;
                        exp = document.SelectSingleNode(XPATH_EXPONENT_ENVIO_BOLETA, ns).InnerText;
                        break;
                    case Firma.TipoXML.DTE:
                       mod = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_MODULUS.Replace("sii:", "") : XPATH_MODULUS, ns).InnerText;
                        exp = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_EXPONENT.Replace("sii:", "") : XPATH_EXPONENT, ns).InnerText;
                        break;                    
                    case Firma.TipoXML.LCV:
                        mod = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_MODULUS_LCV.Replace("sii:", "") : XPATH_MODULUS_LCV, ns).InnerText;
                        exp = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_LCV.Replace("sii:", "") : XPATH_EXPONENT_LCV, ns).InnerText;
                        break;
                    case Firma.TipoXML.Resultado:
                        mod = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_MODULUS_RESULT.Replace("sii:", "") : XPATH_MODULUS_RESULT, ns).InnerText;
                        exp = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_RESULT.Replace("sii:", "") : XPATH_EXPONENT_RESULT, ns).InnerText;
                        break;
                    case Firma.TipoXML.RCOF:
                        mod = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_MODULUS_RCOF.Replace("sii:", "") : XPATH_MODULUS_RCOF, ns).InnerText;
                        exp = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_RCOF.Replace("sii:", "") : XPATH_EXPONENT_RCOF, ns).InnerText;
                        break;
                    case Firma.TipoXML.LibroBoletas:
                        mod = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_MODULUS_LIBROBOLETAS.Replace("sii:", "") : XPATH_MODULUS_LIBROBOLETAS, ns).InnerText;
                        exp = document.SelectSingleNode(string.IsNullOrEmpty(document.DocumentElement.NamespaceURI) ? XPATH_EXPONENT_LIBROBOLETAS.Replace("sii:", "") : XPATH_EXPONENT_LIBROBOLETAS, ns).InnerText;
                        break;
                    default:
                        throw new Exception();
                }

                string publicKeyXml = string.Empty;

                publicKeyXml += "<RSAKeyValue>";
                publicKeyXml += "<Modulus>{0}</Modulus>";
                publicKeyXml += "<Exponent>{1}</Exponent>";
                publicKeyXml += "</RSAKeyValue>";

                publicKeyXml = string.Format(publicKeyXml, mod, exp);

                RSACryptoServiceProvider publicKey = new RSACryptoServiceProvider();
                publicKey.FromXmlString(publicKeyXml);

                SignedXml signedXml = new SignedXml(document);

                XmlNodeList nodeList = document.GetElementsByTagName("Signature");

                signedXml.LoadXml((XmlElement)nodeList[tipoXml == Firma.TipoXML.Envio || tipoXml == Firma.TipoXML.EnvioBoleta ? nodeList.Count - 1 : 0]);

                return signedXml.CheckSignature(publicKey);
            }
            catch (Exception ex)
            {
                messageOut = ex.ToString();
                return false;
            }
        }

        /// <summary>
        ///  Obtiene la firma de un xml en formato XmlDocument
        /// </summary>
        /// <param name="document"> documento en formato xml</param>
        /// <returns></returns>
        public static string GetFirmaXmlDocument(this XmlDocument document)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(document.NameTable);
            ns.AddNamespace("sii", document.DocumentElement.NamespaceURI);
            ns.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");

            return document.SelectSingleNode(XPATH_FIRMA_DTE, ns).InnerText;
        }

        

        #endregion
    }
}
