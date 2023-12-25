using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.FormulaFields
{
    public class FormulaFieldParameter : RequestParameter
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string ProcessCode { get; set; }

    }
}
