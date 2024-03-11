using Shopfloor.Core.Models.Parameters;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Parameters.OneHundredPointSystemDetails
{
    public class OneHundredPointSystemDetailParameter : RequestParameter
    {
        public decimal? FromKg { get; set; }
		public decimal? ToKg { get; set; }
		public int? FromDefect { get; set; }
		public int? ToDefect { get; set; }
		public OneHundredPointType? Point { get; set; }
    }
}
