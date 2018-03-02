using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLConfigCreator.Enums.Base;

namespace XMLConfigCreator.Enums
{
    public class CombosValues
    {
        public class TrueFalse : StringBase<TrueFalse>
        {
            public const string False = "false";
            public const string True = "true";
        }

        public class Engine : StringBase<Engine>
        {
            public const string AR = "AR";
            public const string RS = "RS";
        }

        public class FormatText : StringBase<FormatText>
        {
            public const string None = "None";
            public const string Enumeration = "Enumeration";
            public const string Custom = "Custom";
            public const string Button = "Button";
        }

        public class ActionButton : StringBase<ActionButton>
        {
            public const string AccionNuevo = "AccionNuevo";
            public const string AccionEliminar = "AccionEliminar";
        }
    }
}
