using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using XMLConfigCreator.CustomExceptions.ValidationModels;

namespace XMLConfigCreator.CustomExceptions
{
    public class ValidationException : Exception
    {
        List<ValidationExceptionObject> oVal = new List<ValidationExceptionObject>();

        public ValidationException() {}

        public ValidationException(List<ValidationExceptionObject> oVal)
        {
            this.oVal = oVal;
        }

        public void ShowMessage()
        {
            if (oVal.Count > 0)
            {
                DlgException dlg = new DlgException();
                dlg.oVal.AddRange(oVal);
                dlg.ShowDialog();
            }
        }

    }
}
