using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingTasks
{
    public class SewingTaskModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LineCode { get; set; }
        public string Freq { get; set; }
        public decimal TotalTMU { get; set; }
        public bool Deleted { get; set; }
    }
}
