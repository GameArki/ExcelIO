using System;

namespace GameArki.ExcelIO {

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ExcelTableMainKeyAttribute : Attribute {

        public ExcelTableMainKeyAttribute() { }

    }

}