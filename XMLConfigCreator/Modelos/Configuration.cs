using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLConfigCreator.CustomExceptions.ValidationModels;
using XMLConfigCreator.Enums;

namespace XMLConfigCreator.Modelos
{
    [XmlRoot("Configuration")]
    public class Configuration : ValidateModelBase
    {

        public Configuration()
        {
            //ExceptionButtons = new ExceptionButtons();
            ColumnasVisibles = new ColumnasVisibles();
        }

        [XmlAttribute("Entidad")]
        public string Entidad { get; set; }

        [XmlAttribute("xmlns")]
        public string xmlns { get; set; }

        [XmlElement("Vista")]
        public Vista Visita { get; set; }

        [XmlElement("Impresion")]
        public Impresion Impresion { get; set; }

        [XmlElement("ExceptionButton")]
        public ExceptionButtons ExceptionButtons { get; set; }

        [XmlElement("ColumnasVisibles")]
        public ColumnasVisibles ColumnasVisibles { get; set; }

        public override List<ValidationExceptionObject> ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(Entidad))
                ValidationObjectList.Add(new ValidationExceptionObject(nameof(Entidad), string.Format(ExceptionValues.ValorVacio, nameof(Entidad))));

            return base.ValidationObjectList;
        }
    }
}
