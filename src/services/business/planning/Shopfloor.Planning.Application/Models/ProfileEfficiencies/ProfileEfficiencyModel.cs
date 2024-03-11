using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.ProfileEfficiencyDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Models.ProfileEfficiencies
{
    public class ProfileEfficiencyModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public int? ProductGroupId { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public virtual ICollection<ProfileEfficiencyDetailModel> ProfileEfficiencyDetails { get; set; }
    }
}
