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
                { "A", nameof(UploadExcelImportDetailModel.PONo) },
                { "B", nameof(UploadExcelImportDetailModel.ArticleName) },
                { "C", nameof(UploadExcelImportDetailModel.ArticleCode) },
                { "D", nameof(UploadExcelImportDetailModel.Unit) },
                { "E", nameof(UploadExcelImportDetailModel.QuantityYard) },
                { "F", nameof(UploadExcelImportDetailModel.QuantityMeter) },
                { "G", nameof(UploadExcelImportDetailModel.Quantity) },
                { "H", nameof(UploadExcelImportDetailModel.Shade) },
                { "I", nameof(UploadExcelImportDetailModel.Grade) },
                { "J", nameof(UploadExcelImportDetailModel.OC) },
                { "K", nameof(UploadExcelImportDetailModel.Size) },
                { "L", nameof(UploadExcelImportDetailModel.Color) },
                { "M", nameof(UploadExcelImportDetailModel.Note) }
          };
    }
}

