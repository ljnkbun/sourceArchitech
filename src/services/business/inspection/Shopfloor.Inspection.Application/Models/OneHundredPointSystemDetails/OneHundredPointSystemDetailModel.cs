using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.OneHundredPointSystemDetails
{
    public class OneHundredPointSystemDetailModel : BaseModel
    {
        public decimal? FromKg { get; set; }
		public decimal? ToKg { get; set; }
		public int? FromDefect { get; set; }
		public int? ToDefect { get; set; }
		public OneHundredPointType? Point { get; set; }
    }
}
