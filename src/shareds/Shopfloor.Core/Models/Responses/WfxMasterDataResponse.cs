namespace Shopfloor.Core.Models.Responses
{
    public class WfxMasterDataResponse<T>
    {
        public int? ResponseID { get; set; }
        public string ErrorMsg { get; set; }
        public List<T> ResponseData { get; set; }
        public string Status { get; set; }
    }
}
