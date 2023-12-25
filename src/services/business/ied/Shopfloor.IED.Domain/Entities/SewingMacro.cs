using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingMacro : BaseMasterEntity
    {
        public SewingMacro()
        {
            SewingMacroBOLs = new HashSet<SewingMacroBOL>();
        }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingMacroBOL> SewingMacroBOLs { get; set; }
    }
}
