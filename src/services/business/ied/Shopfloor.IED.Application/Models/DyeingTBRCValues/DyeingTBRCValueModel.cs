using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DyeingTBRCValues
{
    public class DyeingTBRCValueModel : BaseModel
    {
        public int DyeingTBRChemicalId { get; set; }

        public int DyeingTBRVersionId { get; set; }

        public decimal Value { get; set; }
    }
}