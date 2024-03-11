using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.FactoryCapacitys
{
    public class FactoryCapacityModel : BaseModel
    {
        public int? FactoryId { get; set; }
        public string FactoryName { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Standingcapacity { get; set; }
        public decimal? ActualCapacity { get; set; }
        public decimal? Percent { get; set; }
        public string ColorCode { get; set; }
        public int? Week {  get; set; }
        public int? Month {  get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int? PlanningGroupFactoryId { get; set; }
        public bool IsHighLight {  get; set; }
    }
}
