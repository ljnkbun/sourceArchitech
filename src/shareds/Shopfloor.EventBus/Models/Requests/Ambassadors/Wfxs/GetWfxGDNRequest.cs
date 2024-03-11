namespace Shopfloor.EventBus.Models.Requests
{
    public class GetWfxGDNRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<WFXAPIGDNMovementParams> WFXAPIGDNMovementData { get; set; }
    }

    public class WFXAPIGDNMovementParams
    {
        public string GDNNum { get; set; }
    }

}
