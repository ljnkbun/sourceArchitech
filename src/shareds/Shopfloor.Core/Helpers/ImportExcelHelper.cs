using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Excels;

namespace Shopfloor.Core.Helpers
{
    public static class ImportExcelHelper
    {
        public static List<T> ReadExcel<T>(IFormFile formFile, ImportExcelModel model)
        {
            if (model.FieldMaps == null || model.FieldMaps.Count == 0)
                return new List<T>();

            using var stream = formFile.OpenReadStream();
            var rows = ReadExcel(stream, model);

            if (rows == null || rows.Count == 0)
                return new List<T>();

            return rows
                .Where(x => x.Cells.Any())
                .Select(x => CreateData<T>(x, model.FieldMaps))
                .ToList();
        }

        private static List<IRow> ReadExcel(Stream stream, ImportExcelModel model)
        {
            stream.Position = 0;
            var hssWorkbook = new HSSFWorkbook(stream);
            var sheet = hssWorkbook.GetSheetAt(0);
            var src = new List<IRow>();
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row == null) continue;
                var isbreak = model.EvenReadRow?.Invoke(row);
                if (isbreak == true)
                    break;
                src.Add(row);
            }
            return src;
        }

        private static T CreateData<T>(IRow row, Dictionary<string, string> fieldMaps)
        {
            var cmd = Activator.CreateInstance<T>();
            foreach (var m in fieldMaps)
            {
                var cellAd = new CellReference(m.Key);
                var val = row.Cells.FirstOrDefault(x => x.ColumnIndex == cellAd.Col)?.ToString();
                cmd.SetValue(m.Value, val);
            }
            return cmd;
        }
    }
}