using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.FourPointsSystemDetails
{
    public class FourPointsSystemDetailModel : BaseModel
    {
        public decimal? From { get; set; }
		public decimal? To { get; set; }
		public GradeType? GradeType { get; set; }
    }
}
