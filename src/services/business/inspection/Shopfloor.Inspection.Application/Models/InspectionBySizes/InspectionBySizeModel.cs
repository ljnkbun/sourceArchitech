using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Application.Models.InspectionBySizes
{
    public class InspectionBySizeModel : BaseModel
    {
        public string ColorCode { get; set; }
		public string ColorName { get; set; }
		public string SizeCode { get; set; }
		public string SizeName { get; set; }
		public string Shade { get; set; }
		public string Lot { get; set; }
		public decimal? GRNQty { get; set; }
		public decimal? PreInspectedQty { get; set; }
		public decimal? LotQty { get; set; }
		public decimal? InspectionQty { get; set; }
		public decimal? ActualQty { get; set; }
		public int? NoOfDefect { get; set; }
		public decimal? OKQty { get; set; }
		public decimal? BGroupQty { get; set; }
		public decimal? BGroupUsable { get; set; }
		public decimal? RejectedQty { get; set; }
		public decimal? ExcessShortageQty { get; set; }
		public string ReasonforBGroup { get; set; }
        public int? InspectionId { get; set; }
        public int? QCRequestDetailId { get; set; }
    }
}
