using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperation : BaseMasterEntity
    {
        public SewingOperation()
        {
            SewingFeatureBOLs = new HashSet<SewingFeatureBOL>();
            SewingOperationBOLs = new HashSet<SewingOperationBOL>();
        }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingFeatureBOL> SewingFeatureBOLs { get; set; }
        public virtual ICollection<SewingOperationBOL> SewingOperationBOLs { get; set; }

    }
}
