using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SIMPLE_API.Cesion
{
    public class Cesiones
    {
        //[XmlElement("DTECedido")]
        [XmlIgnore]
        public DTECedido DTECedido { get; set; }

        [XmlElement("Cesiones")]
        public List<Cesion> Cesion { get; set; }

        //[XmlIgnore]
        //public List<string> CesionesFirmadas { get; set; }

        public Cesiones()
        {
            Cesion = new List<Cesion>();
            //CesionesFirmadas = new List<string>();
        }
    }
}
