using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.ProfileEfficiencyDetails
{
    public class ProfileEfficiencyDetailParameter : RequestParameter
    {
        public int? ProfileEfficiencyId { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public decimal? EfficiencyValue { get; set; }
    }
}
