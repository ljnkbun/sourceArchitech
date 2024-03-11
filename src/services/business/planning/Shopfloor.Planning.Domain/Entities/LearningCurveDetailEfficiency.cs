using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class LearningCurveDetailEfficiency : BaseMasterEntity
    {
        public int? LearningCurveEfficiencyId { get; set; }
        public int? Days { get; set; }
        public decimal? EfficiencyValue { get; set; }

        public virtual LearningCurveEfficiency LearningCurveEfficiency { get; set; }
    }
}
