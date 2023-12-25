using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.FormulaFields
{
    public class FormulaFieldModel : BaseModel
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string ProcessCode { get; set; }
    }
}
