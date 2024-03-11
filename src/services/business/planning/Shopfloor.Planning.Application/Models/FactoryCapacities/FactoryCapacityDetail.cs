namespace Shopfloor.Planning.Application.Models.FactoryCapacities
{
    public class FactoryCapacityDetail
    {
        public DateTime? Date { get; set; }
        public decimal? Standingcapacity { get; set; }
        public decimal? ActualCapacity { get; set; }
        public decimal? Percent { get; set; }
        public string ColorCode { get; set; }
        public int? Week { get; set; }
        public int? Month { get; set; }
        public bool IsHighLight {  get; set; }
    }
}
