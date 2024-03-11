using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.ProfileEfficiencies
{
    public class ProfileEfficiencyParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int? ProductGroupId { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
    }
}
