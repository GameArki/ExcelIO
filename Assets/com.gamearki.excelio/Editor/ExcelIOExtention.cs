using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace GameArki.ExcelIO {

    public static class ExcelIOExtention {

        static Dictionary<string, string> nameDict = new Dictionary<string, string>() {
            { "Boolean", "bool" },
            { "Byte",    "byte" },
            { "SByte",   "sbyte" },
            { "UInt16",  "ushort" },
            { "Int16",   "short" },
            { "UInt32",  "uint" },
            { "Int32",   "int" },
            { "UInt64",  "ulong" },
            { "Int64",   "long" },
            { "Single",  "float" },
            { "Double",  "double" },
            { "String",  "string" },
        };

        public static string TypeCommonName(this Type fieldType) {
            string n = fieldType.Name;
            bool has = nameDict.TryGetValue(n, out string commonName);
            if (has) {
                return commonName;
            } else {
                Debug.LogError($"ExcelIOExtention.TypeCommonName: nameDict.TryGetValue failed, n = {n}");
                return n;
            }
        }

    }

}