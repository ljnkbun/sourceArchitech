using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingTaskLib : BaseMasterEntity
    {
        public SewingTaskLib()
        {
            SewingMacroLibBOLs = new HashSet<SewingMacroLibBOL>();
            SewingOperationLibBOLs = new HashSet<SewingOperationLibBOL>();
        }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<SewingMacroLibBOL> SewingMacroLibBOLs { get; set; }
        public virtual ICollection<SewingOperationLibBOL> SewingOperationLibBOLs { get; set; }
    }
}
