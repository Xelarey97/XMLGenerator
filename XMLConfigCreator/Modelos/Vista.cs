using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLConfigCreator.CustomExceptions.ValidationModels;

namespace XMLConfigCreator.Modelos
{
    public class Vista : ValidateModelBase
    {
        [XmlAttribute("Caption")]
        public string Caption { get; set; }

        [XmlAttribute("Recurso")]
        public string Recurso { get; set; }

        [XmlAttribute("MDIBusqueda")]
        public string MDIBusqueda { get; set; }

        [XmlAttribute("MDIEdicion")]
        public string MDIEdicion { get; set; }

        [XmlAttribute("AutoSize")]
        public string AutoSize { get; set; }
    }
}
