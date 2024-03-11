namespace Shopfloor.EventBus.Models.Requests
{
    public class GetQCDefinitionDefectsRequest : BaseRequest
    {
        public int? QCDefinitionId { get; set; }
		public int? QCDefectId { get; set; }
    }
}
