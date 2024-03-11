using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.Imports
{
    public class ImportParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ImportStatus[] Status { get; set; }
        public string Statuses { get; set; }
        public ImportType[] Type { get; set; }
        public string Types { get; set; }
        public string PONo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string WfxStatuses { get; set; }
    }
}
