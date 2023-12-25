namespace Shopfloor.EventBus.Models.Responses
{
    public class GetColorCardByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Reference { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SelectColor { get; set; }
        public string PictureURL { get; set; }
    }
}
