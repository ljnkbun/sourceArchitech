using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.LearningCurveDetailEfficiencies
{
    public class LearningCurveDetailEfficiencyModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public int? Days { get; set; }
        public decimal? EfficiencyValue { get; set; }
    }
}
