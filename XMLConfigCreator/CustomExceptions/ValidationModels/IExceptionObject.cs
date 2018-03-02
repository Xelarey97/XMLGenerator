using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLConfigCreator.CustomExceptions.ValidationModels
{
    interface IExceptionObject
    {
        string Nombre { get; set; }
        string Valor { get; set; }
    }
}
