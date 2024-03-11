using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.MergeSplitPORs
{
    public class MergeSplitPORParameter : RequestParameter
    {
        public int? FromPORId { get; set; }
        public int? ToPORId { get; set; }
        public decimal Quantity { get; set; }
    }
}
