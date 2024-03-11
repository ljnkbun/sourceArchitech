using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DCTemplateDetail : BaseEntity
    {
        public int DCTemplateTaskId { get; set; }
        public int ChemicalId { get; set; }
        public string ChemicalSubCategory { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }
        public virtual DCTemplateTask DcTemplateTask { get; set; }
    }
}