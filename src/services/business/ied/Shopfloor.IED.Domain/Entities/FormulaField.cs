using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class FormulaField : BaseEntity
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string ProcessCode { get; set; }
    }
}
