using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.Imports
{
    public class ImportModel : BaseModel
    {
        public string Note { get; set; }
        public ImportStatus? Status { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ImportType? Type { get; set; }

    }
}
