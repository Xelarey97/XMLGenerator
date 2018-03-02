using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLConfigCreator.CustomExceptions.ValidationModels
{
    public class ValidationExceptionObject : IExceptionObject
    {
        public string Nombre { get; set; }

        public string Valor { get; set; }

        public ValidationExceptionObject(string nombre, string valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}
