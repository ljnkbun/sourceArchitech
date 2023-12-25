using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RecipeChemical : BaseEntity
    {
        public int RecipeTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }

        public virtual RecipeTask RecipeTask { get; set; }
    }
}