using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClosedXML.Excel;

namespace GameArki.ExcelIO {

    public static class ExcelIOCore {

        // - Create
        public static void CreateWorkBook<T>(string excelPath, string sheetName = null) {

            var workbook = new XLWorkbook();
            var type = typeof(T);
            var sheet = workbook.Worksheets.Add(sheetName == null ? type.Name : sheetName);

            // - 反射
            var fields = type.GetFields();
            int columnCount = fields.Length;

            // - 设置头部
            for (int i = 0; i < columnCount; i += 1) {
                var field = fields[i];
                sheet.Cell(1, i + 1).Value = field.Name;
            }

            // - 设置数据类型
            for (int i = 0; i < columnCount; i += 1) {
                var field = fields[i];
                sheet.Cell(2, i + 1).Value = field.FieldType.TypeCommonName();
            }

            workbook.SaveAs(excelPath);

        }

        // - Open
        public static XLWorkbook OpenWorkbook(string excelPath) {
            return new XLWorkbook(excelPath);
        }

        // - Query
        public static T[] Query<T>(this XLWorkbook excel, string sheetName) where T : class {

            var sheet = excel.Worksheet(sheetName);

            var list = new List<T>();

            int rowCount = sheet.LastRowUsed().RowNumber();
            int columnCount = sheet.LastColumnUsed().ColumnNumber();

            if (rowCount < 3) {
                Debug.LogError($"ExcelIOCore.Query: rowCount < 3, rowCount = {rowCount}");
                return null;
            }

            // 第一行: 头部, 是字段名
            var headRow = sheet.Row(1);

            // 第二行: 数据类型
            var typeRow = sheet.Row(2);

            // 第三行起: 数据
            // - 反射
            Dictionary<string, FieldInfo> fieldDict = new Dictionary<string, FieldInfo>();
            var fields = typeof(T).GetFields();
            foreach (var field in fields) {
                fieldDict.Add(field.Name, field);
            }

            if (fields.Length != columnCount) {
                Debug.LogError($"ExcelIOCore.Query: fields.Length != columnCount, fields.Length = {fields.Length}, columnCount = {columnCount}");
                return null;
            }

            // - 查表并设置对象
            for (int i = 3; i <= rowCount; i += 1) {
                T obj = Activator.CreateInstance<T>();
                var row = sheet.Row(i);
                for (int j = 1; j <= columnCount; j += 1) {
                    string fieldName = headRow.Cell(j).Value.GetText();
                    string typeName = typeRow.Cell(j).Value.GetText();
                    string cellValue = row.Cell(j).Value.ToString();
                    SetValue(obj, fieldDict, fieldName, typeName, cellValue);
                }
                list.Add(obj);
            }

            return list.ToArray();

        }

        static void SetValue(object obj, Dictionary<string, FieldInfo> fieldDict, string fieldName, string typeName, string value) {

            bool has = fieldDict.TryGetValue(fieldName, out FieldInfo field);
            if (!has) {
                Debug.LogError($"ExcelIOCore.SetValue: fieldDict.TryGetValue failed, fieldName = {fieldName}");
                return;
            }

            ParseDelegate parser = ExcelIOReflectParseHelper.GetParser(typeName);
            parser.Invoke(obj, field, value);
        }

    }

}
