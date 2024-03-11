using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class ProfileEfficiencyDetail : BaseEntity
    {
        public int ProfileEfficiencyId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public decimal EfficiencyValue { get; set; }
        public virtual ProfileEfficiency ProfileEfficiency { get; set; }
    }
}
