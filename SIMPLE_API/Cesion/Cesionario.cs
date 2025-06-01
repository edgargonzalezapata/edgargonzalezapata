using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SIMPLE_API.Cesion
{
    public class Cesionario
    {
        [XmlElement("RUT")]
        public string RUT { get; set; }

        [XmlElement("RazonSocial")]
        public string RazonSocial { get; set; }

        [XmlElement("Direccion")]
        public string Direccion { get; set; }

        [XmlElement("eMail")]
        public string eMail { get; set; }
    }
}
