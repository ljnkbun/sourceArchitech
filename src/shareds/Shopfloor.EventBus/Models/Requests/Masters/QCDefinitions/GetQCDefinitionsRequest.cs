namespace Shopfloor.EventBus.Models.Requests
{
    public class GetQCDefinitionsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal? AcceptanceValue { get; set; }
		public int? SamplingId { get; set; }
		public int? TestGroupId { get; set; }
		public int? ConversionId { get; set; }
    }
}
