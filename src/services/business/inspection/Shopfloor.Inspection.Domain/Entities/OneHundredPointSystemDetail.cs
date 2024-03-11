using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class OneHundredPointSystemDetail : BaseEntity
    {
        public decimal? FromKg { get; set; }
		public decimal? ToKg { get; set; }
		public int? FromDefect { get; set; }
		public int? ToDefect { get; set; }
		public OneHundredPointType Point { get; set; }
        public int OneHundredPointSystemId { get; set; }
        public virtual OneHundredPointSystem OneHundredPointSystem { get; set; }
    }
}
