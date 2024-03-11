using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.QCDefinitions
{
    public class QCDefinitionParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal? AcceptanceValue { get; set; }
		public int? SamplingId { get; set; }
		public int? ConversionId { get; set; }
        public int? QCTypeId { get; set; }
        public decimal? PercentQC { get; set; }
        public decimal? PercentAcceptance { get; set; }
        public decimal? FixedQty { get; set; }
        public decimal? AcceptanceQty { get; set; }
        public decimal? Quantity { get; set; }
        public int? AQLVersionId { get; set; }
        public int? FourPointsSystemId { get; set; }
        public int? OneHundredPointSystemId { get; set; }
    }
}
