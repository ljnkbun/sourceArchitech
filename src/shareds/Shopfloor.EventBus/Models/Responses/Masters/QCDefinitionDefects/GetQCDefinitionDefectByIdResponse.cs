namespace Shopfloor.EventBus.Models.Responses
{
    public class GetQCDefinitionDefectByIdResponse : BaseResponse
    {
        public int? QCDefinitionId { get; set; }
		public int? QCDefectId { get; set; }
    }
}
