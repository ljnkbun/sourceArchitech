using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.Formulas
{
    public class FormulaModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }
        public string ProcessCode { get; set; }
    }
}
