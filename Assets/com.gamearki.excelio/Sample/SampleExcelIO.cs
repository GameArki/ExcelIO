using System.IO;
using UnityEngine;
using UnityEditor;
using SW = System.Diagnostics.Stopwatch;

namespace GameArki.ExcelIO.Sample {

    public static class SampleExcelIO {

        class ExcelDTO {
            public byte byteValue;
            public sbyte sbyteValue;
            public ushort ushortValue;
            public short shortValue;
            public uint uintValue;
            public int intValue;
            public ulong ulongValue;
            public long longValue;
            public float floatValue;
            public bool boolValue;
            public string stringValue;
        }

        [MenuItem("Samples/ExcelIO/Run")]
        public static void Run() {

            string sampleDir = Path.Combine(Application.dataPath, "com.gamearki.excelio", "Sample");

            // Create(Path.Combine(sampleDir, "excel_new.xlsm"), nameof(ExcelDTO));

            Query(Path.Combine(sampleDir, "excel_query.xlsm"), nameof(ExcelDTO));
            
        }

        static void Create(string path, string sheetName) {
            ExcelIOCore.CreateWorkBook<ExcelDTO>(path, sheetName);
        }

        static void Query(string path, string sheetName) {
            var sw = new SW();
            sw.Start();
            var excel = ExcelIOCore.OpenWorkbook(path);
            sw.Stop();
            Debug.Log($"excel = {excel}, sw.ElapsedMilliseconds = {sw.Elapsed.TotalMilliseconds}");

            sw.Reset();
            sw.Start();
            var dtoArr = excel.Query<ExcelDTO>(sheetName);
            sw.Stop();
            Debug.Log($"dtoArr = {dtoArr}, sw.ElapsedMilliseconds = {sw.Elapsed.TotalMilliseconds}");

            for (int i = 0; i < dtoArr.Length; i += 1) {
                var dto = dtoArr[i];
            }
        }

    }

}