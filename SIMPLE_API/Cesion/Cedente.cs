using ChileSystems.DTE.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SIMPLE_API.Cesion
{
    public class Cedente
    {
        [XmlElement("RUT")]
        public string RUT { get; set; }

        [XmlElement("RazonSocial")]
        public string RazonSocial { get; set; }

        [XmlIgnore]
        private string _dirOrigen;

        [XmlElement("Direccion")]
        public string Direccion { get { return _dirOrigen.Truncate(80); } set { _dirOrigen = value; } }


        [XmlElement("eMail")]
        public string eMail { get; set; }

        [XmlElement("RUTAutorizado")]
        public List<RUTAutorizado> RUTsAutorizados { get; set; }

        [XmlElement("DeclaracionJurada")]
        public string DeclaracionJurada { get; set; }
    }
}
