using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingSubcategoryEfficiencies
{
    public class SewingSubcategoryEfficiencyModel : BaseModel
    {
        public int SewingEfficiencyProfileId { get; set; }

        public string SubCategory { get; set; }
    }
}