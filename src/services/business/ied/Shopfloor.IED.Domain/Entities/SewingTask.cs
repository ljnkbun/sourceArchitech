using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingTask : BaseMasterEntity
    {
        public SewingTask()
        {
            SewingMacroBOLs = new HashSet<SewingMacroBOL>();
            SewingOperationBOLs = new HashSet<SewingOperationBOL>();
        }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<SewingMacroBOL> SewingMacroBOLs { get; set; }
        public virtual ICollection<SewingOperationBOL> SewingOperationBOLs { get; set; }
    }
}
