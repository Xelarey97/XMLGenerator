using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLConfigCreator.Modelos
{
    public class Button : ValidateModelBase
    {
        [XmlAttribute("Clave")]
        public string Clave { get; set; }

        [XmlAttribute("Valor")]
        public string Valor { get; set; }
    }
}
