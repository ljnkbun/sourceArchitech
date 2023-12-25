namespace Shopfloor.EventBus.Models.Responses
{
    public class GetFabricWidthByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
}
