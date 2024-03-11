using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InspectionDefectError100PointSys : BaseEntity
    {
        public int InspectionDefectCapturing100PointSysId { get; set; }
		public ErrorType ErrorType { get; set; }
		public decimal From { get; set; }
		public decimal? To { get; set; }
        public virtual InspectionDefectCapturing100PointSys InspectionDefectCapturing100PointSys { get; set; }
    }
}
