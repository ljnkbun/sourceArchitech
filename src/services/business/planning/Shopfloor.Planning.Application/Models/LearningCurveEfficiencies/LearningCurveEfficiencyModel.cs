using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.LearningCurveEfficiencies
{
    public class LearningCurveEfficiencyModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
