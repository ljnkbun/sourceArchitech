using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.Inpection100PointSyss
{
    public class Inpection100PointSysParameter : RequestParameter
    {
        public int? QCRequestArticleId { get; set; }
		public string StockMovementNo { get; set; }
		public decimal? CaptureMeter { get; set; }
		public decimal? ActualWeight { get; set; }
		public int? TotalDefect { get; set; }
		public int? TotalContDefect { get; set; }
		public int? TotalPoint { get; set; }
		public int? PointSquareMeter { get; set; }
		public int? WarpDensity { get; set; }
		public int? WeftDensity { get; set; }
		public int? PersonInChargeId { get; set; }
		public string Remark { get; set; }
		public int? AttachmentId { get; set; }
		public bool? SystemResult { get; set; }
		public bool? UserResult { get; set; }
		public string Grade { get; set; }
		public decimal? WeightGM2 { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public DateTime? InspectionDate { get; set; }
    }
}
