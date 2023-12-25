using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.DyeingTBMaterialColors
{
    public class DyeingTBMaterialColorParameter : RequestParameter
    {
        public int? DyeingTBMaterialId { get; set; }

        public string Color { get; set; }

        public string Pantone { get; set; }

        public TBMaterialColorStatus? Status { get; set; }
    }
}