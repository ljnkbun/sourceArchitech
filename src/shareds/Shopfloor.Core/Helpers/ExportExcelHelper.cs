using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Shopfloor.Core.Helpers
{
    public static class ExportExcelHelper
    {
        public static MemoryStream WriteExcelHSSF(string tempFilePath, ExcelInputDataModel model)
        {
            var tempStream = new FileStream(tempFilePath, FileMode.Open);
            HSSFWorkbook workbook = new HSSFWorkbook(tempStream);
            if (model.Type == 0)
            {
                var sheet = workbook.GetSheetAt(model.SheetIndex);
                WriteSheet(sheet, model.RowIndex, model.Data, model.ReFormat);
            }
            else
            {
                var sheet = workbook.GetSheetAt(model.SheetIndex);
                WriteSheetRows(sheet, model.DataDic, model.DataCreateRows, model.ReFormat);
            }
            tempStream.Close();
            var ms = new MemoryStream();
            workbook.Write(ms);
            return ms;
        }

        public static MemoryStream WriteExcelXSSF(string tempFilePath, ExcelInputDataModel model)
        {
            var tempStream = new FileStream(tempFilePath, FileMode.Open);
            XSSFWorkbook workbook = new XSSFWorkbook(tempStream);
            var sheet = workbook.GetSheetAt(model.SheetIndex);
            WriteSheet(sheet, model.RowIndex, model.Data, model.ReFormat);
            tempStream.Close();
            var ms = new MemoryStream();
            workbook.Write(ms);
            return ms;
        }

        public static MemoryStream WriteExcelXSSF(string tempFilePath, ExcelDataModel model)
        {
            var tempStream = new FileStream(tempFilePath, FileMode.Open);
            XSSFWorkbook workbook = new XSSFWorkbook(tempStream);
            var sheet = workbook.GetSheetAt(model.SheetIndex);
            WriteSheetRows(sheet, model.Data, model.IsCreateNewRows, model.ReFormat);
            tempStream.Close();
            var ms = new MemoryStream();
            workbook.Write(ms);
            return ms;
        }

        private static void WriteSheet(ISheet sheet, int rowIndex, List<Dictionary<string, object>> data, bool reFormat)
        {
            foreach (var r in data)
            {
                IRow row = sheet.CreateRow(rowIndex);
                WriteRow(row, r, reFormat);
                rowIndex++;
            }
        }

        private static void WriteSheetRows(ISheet sheet, Dictionary<int, Dictionary<string, object>> data, Dictionary<int, bool> createRows, bool reFormat)
        {
            foreach (var r in data)
            {
                var row = createRows[r.Key] ? sheet.CopyRow(r.Key + 1, r.Key) : sheet.GetRow(r.Key);
                WriteRow(row, r.Value, reFormat);
            }
        }

        private static void WriteRow(IRow row, Dictionary<string, object> dicValues, bool reFormat)
        {
            foreach (var d in dicValues)
            {
                var colIndex = new CellReference(d.Key).Col;
                var cell = row.GetCell(colIndex) ?? row.CreateCell(colIndex);
                WriteCell(cell, d.Value, reFormat);
            }
        }

        private static void WriteCell(ICell cell, object value, bool reFormat = false)
        {
            if (!reFormat)
            {
                cell.CellStyle.Alignment = value switch
                {
                    decimal _ => HorizontalAlignment.Right,
                    int _ => HorizontalAlignment.Right,
                    string _ => HorizontalAlignment.Left,
                    DateTime _ => HorizontalAlignment.Center,
                    _ => HorizontalAlignment.General,
                };
                cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
            }

            switch (value)
            {
                case decimal decimalValue:
                    cell.SetCellValue((double)decimalValue);
                    break;

                case int intValue:
                    cell.SetCellValue(intValue);
                    break;

                case string stringValue:
                    cell.SetCellValue(stringValue ?? "");
                    break;

                case DateTime dateTimeValue:
                    cell.SetCellValue(dateTimeValue);
                    break;

                default:
                    cell.SetCellValue(value?.ToString() ?? "");
                    break;
            }
        }
    }

    public class ExcelInputDataModel
    {
        public int SheetIndex { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }
        public Dictionary<int, Dictionary<string, object>> DataDic { get; set; }
        public Dictionary<int, bool> DataCreateRows { get; set; }
        public int RowIndex { get; set; }
        public bool ReFormat { get; set; }
        public int Type { get; set; }
    }
    public class ExcelDataModel
    {
        public int SheetIndex { get; set; }
        public Dictionary<int, Dictionary<string, object>> Data { get; set; }
        public Dictionary<int, bool> IsCreateNewRows { get; set; }
        public int RowIndex { get; set; }
        public bool ReFormat { get; set; }
    }
}