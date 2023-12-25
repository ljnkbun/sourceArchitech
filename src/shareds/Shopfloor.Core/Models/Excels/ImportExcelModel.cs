using NPOI.SS.UserModel;

namespace Shopfloor.Core.Models.Excels
{
    public class ImportExcelModel
    {
        public Func<IRow, bool> EvenReadRow { get; set; }
        public int SheetIndex { get; set; }
        public int StartRow { get; set; }
        public Dictionary<string, string> FieldMaps { get; set; }

        public ImportExcelModel(int sheetIndex, int startRow, Dictionary<string, string> fieldMaps)
        {
            SheetIndex = sheetIndex;
            StartRow = startRow;
            FieldMaps = fieldMaps;
        }
    }
}
