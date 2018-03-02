using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XMLConfigCreator.Enums.Base
{
    public class StringBase<T>
    {
        //Devuelve en una lista el contenido de todos los campos definidos "public const string", o 'null' si ha habido algún problema.
        public static List<string> GetValues(T t)
        {
            List<string> oConstantes = new List<string>();
            try
            {
                //Abstraemos todos los fields de la clase
                foreach (FieldInfo fi in t.GetType().GetFields())
                {
                    //Obtenemos el valor de cada field, y lo incluimos en la lista
                    string oValue = (string)fi.GetValue(t);
                    oConstantes.Add(oValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oConstantes;
        }
    }
}
