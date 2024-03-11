using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DyeingTBRChemicalValues
{
    public class DyeingTBRChemicalValueModel : BaseModel
    {
        public int DyeingTBRChemicalId { get; set; }

        public int VersionIndex { get; set; }

        public decimal Value { get; set; }
    }
}