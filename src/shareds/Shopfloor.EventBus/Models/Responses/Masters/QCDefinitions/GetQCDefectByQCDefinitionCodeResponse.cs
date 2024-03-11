using Shopfloor.EventBus.Models.Dtos;

namespace Shopfloor.EventBus.Models.Responses
{
    public class GetQCDefectByQCDefinitionCodeResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal? AcceptanceValue { get; set; }
		public int SamplingId { get; set; }
		public int TestGroupId { get; set; }
		public int ConversionId { get; set; }
        public List<QCDefectDto> QCDefects { get; set;}
    }
}
