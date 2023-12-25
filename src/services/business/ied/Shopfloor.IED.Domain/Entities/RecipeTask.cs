using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RecipeTask : BaseEntity
    {
        public RecipeTask()
        {
            RecipeChemicals = new HashSet<RecipeChemical>();
        }

        public int RecipeId { get; set; }

        public string DyeingOpreation { get; set; }

        public string MachineType { get; set; }

        public int Minutes { get; set; }

        public decimal Temperature { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual ICollection<RecipeChemical> RecipeChemicals { get; set; }
    }
}