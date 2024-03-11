namespace Shopfloor.Ambassador.Application.Parameters
{
    public class WfxGDIParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<WFXAPIGDIMovementData> WFXAPIGDIMovementData { get; set; }

    }

    public class WFXAPIGDIMovementData
    {
        public string GDIDateFrom { get; set; }
        public string GDIDateTo { get; set; }
    }


}
