using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Application.Models.DyeingTBMaterials;

namespace Shopfloor.IED.Application.Models.DyeingTBMaterialColors
{
    public class DyeingTBMaterialColorModel : BaseModel
    {
        public int DyeingTBMaterialId { get; set; }

        public string Color { get; set; }

        public string Pantone { get; set; }

        public bool Deleted { get; set; }

        public DyeingTBMaterialModel DyeingTBMaterial { get; set; }
    }
}