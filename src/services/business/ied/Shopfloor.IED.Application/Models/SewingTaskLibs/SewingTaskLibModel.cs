using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingTaskLibs
{
    public class SewingTaskLibModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal BundelTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public bool Deleted { get; set; }
    }
}
