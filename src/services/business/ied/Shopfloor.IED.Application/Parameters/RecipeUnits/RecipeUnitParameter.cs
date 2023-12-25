using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RecipeUnits
{
    public class RecipeUnitParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
