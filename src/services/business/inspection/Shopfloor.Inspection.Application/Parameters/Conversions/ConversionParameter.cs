using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.Conversions
{
    public class ConversionParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }

    }
}
