using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.MergeSplitPorDetails
{
    public class MergeSplitPorDetailParameter : RequestParameter
    {
        public int? FromPorDetailId { get; set; }
        public int? ToPorDetailId { get; set; }
        public decimal Quantity { get; set; }
    }
}
