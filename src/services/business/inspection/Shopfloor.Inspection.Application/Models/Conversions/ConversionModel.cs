using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Application.Models.Conversions
{
    public class ConversionModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }

    }
}
