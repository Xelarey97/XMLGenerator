using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLConfigCreator.Modelos
{
    public class ExceptionButtons
    {

        public ExceptionButtons()
        {
            this.AfterBusqueda = new AfterBusqueda();
            this.BeforeBusqueda = new BeforeBusqueda();
        }

        [XmlElement("BeforeBusqueda")]
        public BeforeBusqueda BeforeBusqueda { get; set; }

        [XmlElement("AfterBusqueda")]
        public AfterBusqueda AfterBusqueda { get; set; }
    }

    public class AfterBusqueda
    {
        public AfterBusqueda() { this.Button = new List<Button>(); }

        [XmlElement("Button")]
        public List<Button> Button { get; set; }

    }

    public class BeforeBusqueda
    {
        public BeforeBusqueda() { this.Button = new List<Button>(); }

        [XmlElement("Button")]
        public List<Button> Button { get; set; }

    }
}
