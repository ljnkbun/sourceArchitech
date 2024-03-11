using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.InpectionTCStandards
{
    public class InpectionTCStandardParameter : RequestParameter
    {
        public int? QCRequestArticleId { get; set; }
		public string StockMovementNo { get; set; }
		public string Grade { get; set; }
		public bool? Result { get; set; }
		public int? PersonInChargeId { get; set; }
		public string Remark { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public DateTime? InspectionDate { get; set; }
    }
}
