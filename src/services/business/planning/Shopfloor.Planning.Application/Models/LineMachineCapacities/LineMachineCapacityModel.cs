using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.LineMachineCapacities
{
    public class LineMachineCapacityModel : BaseModel
    {
        public int? MachineId { get; set; }
        public string MachineName { get; set; }
        public int? LineId { get; set; }
        public string LineName { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Standingcapacity { get; set; }
        public decimal? WorkingHours { get; set; }
        public int? Week {  get; set; }
        public int? Month {  get; set; }
    }

    public class LineMachineCapcityCustomModel
    {
        public LineMachineCapcityCustomModel()
        {
            LineMachineCapacities = new List<LineMachineCapacityDetail>();
        }
        public int? MachineId { get; set; }
        public string MachineName { get; set; }
        public int? LineId { get; set; }
        public string LineName { get; set; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }
        public List<LineMachineCapacityDetail> LineMachineCapacities { get; set; }
    }

    public class LineMachineCapacityDetail
    {
        public DateTime? Date { get; set; }
        public decimal? Standingcapacity { get; set; }
        public decimal? WorkingHours { get; set; }
        public int? Week { get; set; }
        public int? Month { get; set; }
    }
}
