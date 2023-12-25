using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Application.Models.ImportPODetails;

namespace Shopfloor.Barcode.Application.Definitions
{
    public static class FieldMaps
    {
        public static Dictionary<string, string> ExportDetail => new()
            {
                { "A", nameof(ExportDetailExcelModel.Code) },
                { "B", nameof(ExportDetailExcelModel.Name) },
                { "C", nameof(ExportDetailExcelModel.Barcode) },
                { "D", nameof(ExportDetailExcelModel.QtyYard) },
                { "E", nameof(ExportDetailExcelModel.QtyMet) },
                { "F", nameof(ExportDetailExcelModel.QtyUnit) },
                { "G", nameof(ExportDetailExcelModel.Shade) },
                { "H", nameof(ExportDetailExcelModel.OC) },
                { "I", nameof(ExportDetailExcelModel.Color) },
                { "J", nameof(ExportDetailExcelModel.Size) },
                { "K", nameof(ExportDetailExcelModel.Note) }
            };

        public static Dictionary<string, string> ImportDetails =>
          new()
          {
                { "A", nameof(UploadExcelImportDetailModel.ArticleName) },
                { "B", nameof(UploadExcelImportDetailModel.ArticleCode) },
                { "C", nameof(UploadExcelImportDetailModel.Quantity) },
                { "D", nameof(UploadExcelImportDetailModel.UOM) },
                { "E", nameof(UploadExcelImportDetailModel.Unit) },
                { "F", nameof(UploadExcelImportDetailModel.BarCode) },
                { "G", nameof(UploadExcelImportDetailModel.Status) },
                { "H", nameof(UploadExcelImportDetailModel.Shade) },
                { "I", nameof(UploadExcelImportDetailModel.PONo) },
                { "J", nameof(UploadExcelImportDetailModel.OC) },
                { "K", nameof(UploadExcelImportDetailModel.Color) },
                { "L", nameof(UploadExcelImportDetailModel.Size) },
                { "M", nameof(UploadExcelImportDetailModel.Location) },
                { "N", nameof(UploadExcelImportDetailModel.NumberOfCone) },
                { "O", nameof(UploadExcelImportDetailModel.WeightPerCone) },
                { "P", nameof(UploadExcelImportDetailModel.Note) },
          };
    }
}

