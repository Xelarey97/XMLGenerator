using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLConfigCreator.Modelos
{
    public class Impresion : ValidateModelBase
    {
        [XmlAttribute("Caption")]
        public string Caption { get; set; }

        [XmlAttribute("TipoReport")]
        public string TipoReport { get; set; }

        [XmlAttribute("Engine")]
        public string Engine { get; set; }
    }
}
