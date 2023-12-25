using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.RecipeChemicals
{
    public class RecipeChemicalModel : BaseModel
    {
        public int RecipeTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }
    }
}