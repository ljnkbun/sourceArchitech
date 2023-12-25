using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBMaterialColor : BaseEntity
    {
        public DyeingTBMaterialColor()
        {
            DyeingTBRecipes = new HashSet<DyeingTBRecipe>();
        }

        public int DyeingTBMaterialId { get; set; }

        public string Color { get; set; }

        public string Pantone { get; set; }

        public TBMaterialColorStatus Status { get; set; }

        public virtual DyeingTBMaterial DyeingTBMaterial { get; set; }

        public virtual ICollection<DyeingTBRecipe> DyeingTBRecipes { get; set; }
    }
}