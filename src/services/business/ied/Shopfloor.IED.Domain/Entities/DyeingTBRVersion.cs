using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingTBRVersion : BaseEntity
    {
        public DyeingTBRVersion()
        {
            DyeingTBRCValues = new HashSet<DyeingTBRCValue>();
        }

        public int DyeingTBRecipeId { get; set; }

        public int Version { get; set; }

        public DateTime DoTime { get; set; }

        public bool Approved { get; set; }

        public virtual DyeingTBRecipe DyeingTBRecipe { get; set; }

        public virtual ICollection<DyeingTBRCValue> DyeingTBRCValues { get; set; }
    }
}