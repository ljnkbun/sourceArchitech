using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperationLib : BaseMasterEntity
    {
        public SewingOperationLib()
        {
            SewingFeatureLibBOLs = new HashSet<SewingFeatureLibBOL>();
            SewingOperationLibBOLs = new HashSet<SewingOperationLibBOL>();
        }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public int FolderTreeId { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingFeatureLibBOL> SewingFeatureLibBOLs { get; set; }
        public virtual ICollection<SewingOperationLibBOL> SewingOperationLibBOLs { get; set; }
        public virtual FolderTree FolderTree { get; set; }

    }
}
