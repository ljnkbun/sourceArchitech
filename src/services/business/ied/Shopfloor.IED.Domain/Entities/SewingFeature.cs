using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingFeature : BaseMasterEntity
    {
        public SewingFeature()
        {
            SewingFeatureBOLs = new HashSet<SewingFeatureBOL>();
        }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal LabourCost { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal TotalSMV { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingFeatureBOL> SewingFeatureBOLs { get; set; }
    }
}
