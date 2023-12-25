using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingFeatureLib : BaseMasterEntity
    {
        public SewingFeatureLib()
        {
            SewingFeatureLibBOLs = new HashSet<SewingFeatureLibBOL>();
        }
        public string Description { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public int FolderTreeId { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingFeatureLibBOL> SewingFeatureLibBOLs { get; set; }
        public virtual FolderTree FolderTree { get; set; }
    }
}
