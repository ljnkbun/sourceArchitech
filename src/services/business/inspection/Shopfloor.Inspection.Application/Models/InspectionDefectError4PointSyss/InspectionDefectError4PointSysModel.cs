using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.InspectionDefectError4PointSyss
{
    public class InspectionDefectError4PointSysModel : BaseModel
    {
        public int? InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType? ErrorType { get; set; }
		public decimal? From { get; set; }
		public decimal? To { get; set; }
    }
}
