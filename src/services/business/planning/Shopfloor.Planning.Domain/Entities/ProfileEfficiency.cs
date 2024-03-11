using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class ProfileEfficiency : BaseMasterEntity
    {
        public ProfileEfficiency()
        {
            ProfileEfficiencyDetails = new HashSet<ProfileEfficiencyDetail>();
        }
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public virtual ICollection<ProfileEfficiencyDetail> ProfileEfficiencyDetails { get; set; }
    }
}
