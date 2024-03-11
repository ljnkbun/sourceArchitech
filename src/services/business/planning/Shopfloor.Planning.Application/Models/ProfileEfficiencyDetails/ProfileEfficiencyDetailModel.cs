using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.ProfileEfficiencyDetails
{
    public class ProfileEfficiencyDetailModel : BaseModel
    {
        public int ProfileEfficiencyId { get; set; }
        public decimal EfficiencyValue { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
    }
}
