using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            RecipeTasks = new HashSet<RecipeTask>();
            DyeingIEDs = new HashSet<DyeingIED>();
        }

        public int DyeingTBRecipeId { get; set; }

        public string RecipeNo { get; set; }

        public DateTime JobDate { get; set; }

        public string TCFNO { get; set; }

        public string Style { get; set; }

        public string FabricCode { get; set; }

        public string FabricName { get; set; }

        public string Color { get; set; }

        public string LotNo { get; set; }

        public string RollKg { get; set; }

        public string Speed { get; set; }

        public string NozzleA { get; set; }

        public string NozzleB { get; set; }

        public string Method { get; set; }

        public string LAB { get; set; }

        public string InCharge { get; set; }

        public string Manager { get; set; }

        public string Description { get; set; }

        public bool Deleted { get; set; }

        public virtual DyeingTBRecipe DyeingTBRecipe { get; set; }

        public virtual ICollection<DyeingIED> DyeingIEDs { get; set; }

        public virtual ICollection<RecipeTask> RecipeTasks { get; set; }
    }
}