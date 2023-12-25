using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.Exports
{
    public class ExportParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SourceASNNo { get; set; }
        public ExportStatus? Status { get; set; }

    }
}
