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
            var sheet = workbook.GetSheetAt(model.SheetIndex);
            WriteSheet(sheet, model.RowIndex, model.Data);
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
            WriteSheet(sheet, model.RowIndex, model.Data);
            tempStream.Close();
            var ms = new MemoryStream();
            workbook.Write(ms);
            return ms;
        }

        private static void WriteSheet(ISheet sheet, int rowIndex, List<Dictionary<string, object>> data)
        {
            foreach (var r in data)
            {
                IRow row = sheet.CreateRow(rowIndex);
                WriteRow(row, r, true);
                rowIndex++;
            }
        }
        private static void WriteRow(IRow row, Dictionary<string, object> dicValues, bool reformat = true)
        {
            foreach (var d in dicValues)
            {
                var colIndex = new CellReference(d.Key).Col;
                var cell = row.GetCell(colIndex);
                if (cell == null)
                    cell = row.CreateCell(colIndex);
                WriteCell(cell, d.Value, reformat);
            }
        }
        private static void WriteCell(ICell cell, object value, bool reformat = true)
        {
            if (value is decimal)
            {
                cell.SetCellValue(Convert.ToDouble(value));
                if (reformat)
                {
                    cell.CellStyle.Alignment = HorizontalAlignment.Right;
                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                }
            }
            else if (value is int)
            {
                if (reformat)
                {
                    cell.CellStyle.Alignment = HorizontalAlignment.Right;
                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                }
                cell.SetCellValue((int)value);
            }
            else if (value is string)
            {
                if (reformat)
                {
                    cell.CellStyle.Alignment = HorizontalAlignment.Left;
                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                }
                var v = value as string;
                if (v == null)
                    v = "";
                cell.SetCellValue(v);
            }
            else if (value is DateTime)
            {
                if (reformat)
                {
                    cell.CellStyle.Alignment = HorizontalAlignment.Center;
                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                }
                var v = Convert.ToDateTime(value);
                cell.SetCellValue(v);
            }
        }

    }

    public class ExcelInputDataModel
    {
        public int SheetIndex { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }
        public int RowIndex { get; set; }
    }
}
