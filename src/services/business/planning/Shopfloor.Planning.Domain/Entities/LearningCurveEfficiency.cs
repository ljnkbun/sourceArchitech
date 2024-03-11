using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class LearningCurveEfficiency : BaseMasterEntity
    {
        public LearningCurveEfficiency()
        {
            LearningCurveDetailEfficiencies = new HashSet<LearningCurveDetailEfficiency>();
        }
        public string Description { get; set; }

        public virtual ICollection<LearningCurveDetailEfficiency> LearningCurveDetailEfficiencies { get; set; }
    }
}
