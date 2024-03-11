using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Models.SewingSubcategoryEfficiencies
{
    public class SewingSubcategoryEfficiencyParameter : RequestParameter
    {
        public int? SewingEfficiencyProfileId { get; set; }

        public string SubCategory { get; set; }
    }
}