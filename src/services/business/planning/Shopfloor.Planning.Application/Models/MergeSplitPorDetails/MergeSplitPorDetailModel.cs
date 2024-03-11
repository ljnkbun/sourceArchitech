namespace Shopfloor.Planning.Application.Models.MergeSplitPorDetails
{
    public class MergeSplitPorDetailModel
    {
        public int Id { get; set; }
        public int? FromPorDetailId { get; set; }
        public int? ToPorDetailId { get; set; }
        public decimal Quantity { get; set; }
    }
}
