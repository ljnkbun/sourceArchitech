using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.Exports
{
    public class ExportParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SourceASNNo { get; set; }
        public ExportStatus[] Status { get; set; }
        public string Statuses { get; set; }
        public ExportTypes[] Type { get; set; }
        public string Types { get; set; }
        public string WfxStatuses { get; set; }
    }
}
