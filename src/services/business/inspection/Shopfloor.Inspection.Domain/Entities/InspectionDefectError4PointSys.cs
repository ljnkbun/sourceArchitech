using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InspectionDefectError4PointSys : BaseEntity
    {
        public int InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType ErrorType { get; set; }
		public decimal From { get; set; }
		public decimal? To { get; set; }
        public virtual InspectionDefectCapturing4PointSys InspectionDefectCapturing4PointSys { get; set; }
    }
}
