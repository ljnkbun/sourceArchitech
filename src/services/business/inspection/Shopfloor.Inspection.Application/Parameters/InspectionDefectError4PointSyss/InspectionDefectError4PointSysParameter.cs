using Shopfloor.Core.Models.Parameters;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Parameters.InspectionDefectError4PointSyss
{
    public class InspectionDefectError4PointSysParameter : RequestParameter
    {
        public int? InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType? ErrorType { get; set; }
		public decimal? From { get; set; }
		public decimal? To { get; set; }
    }
}
