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
    public class ColumnasVisibles : ValidateModelBase
    {

        public ColumnasVisibles() { this.Columna = new List<Columna>(); }

        [XmlElement("Columna")]
        public List<Columna> Columna { get; set; }

        public override List<ValidationExceptionObject> ValidarCampos()
        {
            if (Columna.Count < 0)
                base.ValidationObjectList.Add(new ValidationExceptionObject(nameof(Columna), ExceptionValues.NoExistenColumnas));
            else
            {
                foreach (var c in Columna)
                {
                    var validation = c.ValidarCampos();
                    if (validation.Count > 0 && validation != null)
                        base.ValidationObjectList.AddRange(validation);
                }
            }

            return base.ValidationObjectList;
        }
    }

    public class Columna : ValidateModelBase
    {
        [XmlAttribute("Campo")]
        public string Campo { get; set; }

        [XmlAttribute("Width")]
        public string Width { get; set; }

        [XmlAttribute("FormatText")]
        public string FormatText { get; set; }

        [XmlAttribute("Enumerable")]
        public string Enumerable { get; set; }

        [XmlAttribute("ConverterType")]
        public string ConverterType { get; set; }

        public override List<ValidationExceptionObject> ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(Campo))
                base.ValidationObjectList.Add(new ValidationExceptionObject(nameof(Campo), string.Format(ExceptionValues.ValorVacio, nameof(Campo))));

            int aux;
            if (!string.IsNullOrWhiteSpace(Width) && !Int32.TryParse(Width, out aux))
                base.ValidationObjectList.Add(new ValidationExceptionObject(nameof(Width), string.Format(ExceptionValues.ValorVacio, nameof(Width))));

            return base.ValidationObjectList;
        }
    }
}
