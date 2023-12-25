namespace Shopfloor.EventBus.Models.Responses
{
    public class GetWfxMasterDataResponse
    {
        public List<WfxMasterDataDto> Data { get; set; }
    }

    public class WfxMasterDataDto
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public int? SortOrder { get; set; }
        public int? InsertedOrderID { get; set; }
        public bool Disable { get; set; }
    }
}
