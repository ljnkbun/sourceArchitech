using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.LearningCurveEfficiencies
{
    public class LearningCurveEfficiencyParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
