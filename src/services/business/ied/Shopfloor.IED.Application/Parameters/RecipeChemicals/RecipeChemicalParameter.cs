using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RecipeChemicals
{
    public class RecipeChemicalParameter : RequestParameter
    {
        public int? RecipeTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string ChemicalSubcategory { get; set; }

        public string Unit { get; set; }

        public decimal? Value { get; set; }
    }
}