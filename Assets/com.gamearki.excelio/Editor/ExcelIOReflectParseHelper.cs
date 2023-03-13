using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GameArki.ExcelIO {

    internal delegate void ParseDelegate(object obj, FieldInfo fieldInfo, string value);

    internal static class ExcelIOReflectParseHelper {

        internal static ParseDelegate GetParser(string typeName) {
            if (parserDict.TryGetValue(typeName, out ParseDelegate parser)) {
                return parser;
            }
            Debug.LogError($"ExcelIOCore.GetParser: parserDict.TryGetValue failed, typeName = {typeName}");
            return null;
        }

        static Dictionary<string, ParseDelegate> parserDict = new Dictionary<string, ParseDelegate>() {
            {"byte", ParseByte},
            {"sbyte", ParseSByte},
            {"int", ParseInt},
            {"uint", ParseUInt},
            {"short", ParseShort},
            {"ushort", ParseUShort},
            {"long", ParseLong},
            {"ulong", ParseULong},
            {"float", ParseFloat},
            {"double", ParseDouble},
            {"bool", ParseBool},
            {"string", ParseString},
        };

        static void ParseByte(object obj, FieldInfo fieldInfo, string value) {
            if (!byte.TryParse(value, out byte byteValue)) {
                Debug.LogError($"ExcelIOCore.ParseByte: byte.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, byteValue);
        }

        static void ParseSByte(object obj, FieldInfo fieldInfo, string value) {
            if (!sbyte.TryParse(value, out sbyte sbyteValue)) {
                Debug.LogError($"ExcelIOCore.ParseSByte: sbyte.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, sbyteValue);
        }

        static void ParseInt(object obj, FieldInfo fieldInfo, string value) {
            if (!int.TryParse(value, out int intValue)) {
                Debug.LogError($"ExcelIOCore.ParseInt: int.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, intValue);
        }

        static void ParseUInt(object obj, FieldInfo fieldInfo, string value) {
            if (!uint.TryParse(value, out uint uintValue)) {
                Debug.LogError($"ExcelIOCore.ParseUInt: uint.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, uintValue);
        }

        static void ParseShort(object obj, FieldInfo fieldInfo, string value) {
            if (!short.TryParse(value, out short shortValue)) {
                Debug.LogError($"ExcelIOCore.ParseShort: short.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, shortValue);
        }

        static void ParseUShort(object obj, FieldInfo fieldInfo, string value) {
            if (!ushort.TryParse(value, out ushort ushortValue)) {
                Debug.LogError($"ExcelIOCore.ParseUShort: ushort.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, ushortValue);
        }

        static void ParseLong(object obj, FieldInfo fieldInfo, string value) {
            if (!long.TryParse(value, out long longValue)) {
                Debug.LogError($"ExcelIOCore.ParseLong: long.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, longValue);
        }

        static void ParseULong(object obj, FieldInfo fieldInfo, string value) {
            if (!ulong.TryParse(value, out ulong ulongValue)) {
                Debug.LogError($"ExcelIOCore.ParseULong: ulong.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, ulongValue);
        }

        static void ParseFloat(object obj, FieldInfo fieldInfo, string value) {
            if (!float.TryParse(value, out float floatValue)) {
                Debug.LogError($"ExcelIOCore.ParseFloat: float.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, floatValue);
        }

        static void ParseDouble(object obj, FieldInfo fieldInfo, string value) {
            if (!double.TryParse(value, out double doubleValue)) {
                Debug.LogError($"ExcelIOCore.ParseDouble: double.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, doubleValue);
        }

        static void ParseBool(object obj, FieldInfo fieldInfo, string value) {
            if (!bool.TryParse(value, out bool boolValue)) {
                Debug.LogError($"ExcelIOCore.ParseBool: bool.TryParse failed, value = {value}");
                return;
            }
            fieldInfo.SetValue(obj, boolValue);
        }

        static void ParseString(object obj, FieldInfo fieldInfo, string value) {
            fieldInfo.SetValue(obj, value);
        }

    }

}