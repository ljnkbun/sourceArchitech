using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingProcessChemical : BaseEntity
    {
        public int DyeingRoutingId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string SubCategoryCode { get; set; }

        public string SubCategoryName { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }
    }
}