using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingSubcategoryEfficiency : BaseEntity
    {
        public int SewingEfficiencyProfileId { get; set; }

        public string SubCategory { get; set; }

        public virtual SewingEfficiencyProfile SewingEfficiencyProfile { get; set; }
    }
}