using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.RecipeTasks
{
    public class RecipeTaskModel : BaseModel
    {
        public int RecipeId { get; set; }

        public string DyeingOpreation { get; set; }

        public string MachineType { get; set; }

        public decimal Time { get; set; }

        public decimal Temperature { get; set; }
    }
}