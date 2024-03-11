using Shopfloor.Core.Models.Parameters;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Parameters.FourPointsSystemDetails
{
    public class FourPointsSystemDetailParameter : RequestParameter
    {
        public decimal? From { get; set; }
		public decimal? To { get; set; }
		public GradeType? GradeType { get; set; }
    }
}
