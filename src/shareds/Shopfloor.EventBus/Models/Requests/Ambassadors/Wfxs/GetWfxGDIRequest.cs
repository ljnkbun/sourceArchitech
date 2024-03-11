namespace Shopfloor.EventBus.Models.Requests
{
    public class GetWfxGDIRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<WFXAPIGDIMovementParams> WFXAPIGDIMovementData { get; set; }
    }

    public class WFXAPIGDIMovementParams
    {
        public string GDIDateFrom { get; set; }
        public string GDIDateTo { get; set; }
    }

}
