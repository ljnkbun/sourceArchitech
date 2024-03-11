using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.Inspections
{
    public class InspectionParameter : RequestParameter
    {
        public DateTime? InspectionDate { get; set; }
		public int? QCRequestArticleId { get; set; }
		public bool? DefaultResult { get; set; }
		public bool? UserResult { get; set; }
		public bool? MeasurementResult { get; set; }
		public decimal? MeasurementQty { get; set; }
		public decimal? InspectionQty { get; set; }
		public string Reason { get; set; }
		public string Remark { get; set; }
		public string Line { get; set; }
		public decimal? TotalDefect { get; set; }
		public string Stage { get; set; }
		public string CuttingTable { get; set; }
		public bool? IsCreatedFromProduction { get; set; }
    }
}
