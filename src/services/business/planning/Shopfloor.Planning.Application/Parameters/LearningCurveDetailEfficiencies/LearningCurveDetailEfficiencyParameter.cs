using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.LearningCurveDetailEfficiencies
{
    public class LearningCurveDetailEfficiencyParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public int? Days { get; set; }
        public decimal? EfficiencyValue { get; set; }
    }
}
