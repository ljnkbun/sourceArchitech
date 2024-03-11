using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperationLib : BaseMasterEntity
    {
        public SewingOperationLib()
        {
            SewingFeatureLibBOLs = new HashSet<SewingFeatureLibBOL>();
            SewingOperationLibBOLs = new HashSet<SewingOperationLibBOL>();
            SewingRoutingBOLs = new HashSet<SewingRoutingBOL>();
            SewingOperationLibResults = new HashSet<SewingOperationLibResult>();
        }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public int FolderTreeId { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingFeatureLibBOL> SewingFeatureLibBOLs { get; set; }
        public virtual ICollection<SewingOperationLibBOL> SewingOperationLibBOLs { get; set; }
        public virtual FolderTree FolderTree { get; set; }
        public virtual SewingComponent SewingComponent { get; set; }
        public virtual ICollection<SewingRoutingBOL> SewingRoutingBOLs { get; set; }
        public virtual ICollection<SewingOperationLibResult> SewingOperationLibResults { get; set; }
    }
}
