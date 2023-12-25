using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.Formulas
{
    public class FormulaParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }
        public string ProcessCode { get; set; }

    }
}
