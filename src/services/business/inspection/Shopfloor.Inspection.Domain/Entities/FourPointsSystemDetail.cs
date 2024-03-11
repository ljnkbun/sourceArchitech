using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class FourPointsSystemDetail : BaseEntity
    {
        public decimal? From { get; set; }
		public decimal? To { get; set; }
		public GradeType GradeType { get; set; }
        public int FourPointsSystemId { get; set; }
        public virtual FourPointsSystem FourPointsSystem { get; set; }
    }
}
