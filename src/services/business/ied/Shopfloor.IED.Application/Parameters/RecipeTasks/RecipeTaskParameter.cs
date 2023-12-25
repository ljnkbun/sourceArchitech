using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RecipeTasks
{
    public class RecipeTaskParameter : RequestParameter
    {
        public int? RecipeId { get; set; }

        public string DyeingOpreation { get; set; }

        public string MachineType { get; set; }

        public int? Minutes { get; set; }

        public decimal? Temperature { get; set; }
    }
}