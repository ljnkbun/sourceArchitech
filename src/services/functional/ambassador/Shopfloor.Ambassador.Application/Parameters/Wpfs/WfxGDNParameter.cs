namespace Shopfloor.Ambassador.Application.Parameters
{
    public class WfxGDNParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<WFXAPIGDNMovementData> WFXAPIGDNMovementData { get; set; }

    }

    public class WFXAPIGDNMovementData
    {
        public string GDNNum { get; set; }
    }


}
