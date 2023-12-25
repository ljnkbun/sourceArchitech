using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.Exports
{
    public class ExportModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }
    }
}
