using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLConfigCreator.CustomExceptions.ValidationModels;
using XMLConfigCreator.Enums;

namespace XMLConfigCreator.Modelos
{
    public class ValidateModelBase
    {
        protected List<ValidationExceptionObject> ValidationObjectList = new List<ValidationExceptionObject>();

        public virtual List<ValidationExceptionObject> ValidarCampos()
        {
            ValidationObjectList = new List<ValidationExceptionObject>();
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(this, null);
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    ValidationObjectList.Add(new ValidationExceptionObject(propertyInfo.Name, string.Format(ExceptionValues.ValorVacio, propertyInfo.Name)));
            }
            return ValidationObjectList;
        }
    }
}
