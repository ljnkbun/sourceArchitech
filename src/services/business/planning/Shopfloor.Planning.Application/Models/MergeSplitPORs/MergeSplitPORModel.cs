using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.MergeSplitPORs
{
    public class MergeSplitPORModel : BaseModel
    {
        public int? FromPORId { get; set; }
        public int? ToPORId { get; set; }
        public decimal Quantity { get; set; }
    }
}
