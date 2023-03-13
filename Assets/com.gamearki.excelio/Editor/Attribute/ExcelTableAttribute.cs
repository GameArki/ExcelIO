using System;

namespace GameArki.ExcelIO {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class ExcelTableAttribute : Attribute {

        public ExcelTableAttribute() { }

    }

}