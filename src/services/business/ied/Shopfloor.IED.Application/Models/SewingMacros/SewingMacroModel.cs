using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingMacros
{
    public class SewingMacroModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public bool Deleted { get; set; }
    }
}
