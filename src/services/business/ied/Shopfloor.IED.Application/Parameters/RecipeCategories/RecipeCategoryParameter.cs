using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RecipeCategories
{
    public class RecipeCategoryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
