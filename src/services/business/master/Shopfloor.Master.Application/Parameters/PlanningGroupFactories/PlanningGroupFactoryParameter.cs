using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.PlanningGroupFactories
{
    public class PlanningGroupFactoryParameter : RequestParameter
    {
        public int? PlanningGroupId { get; set; }
        public int? FactoryId { get; set; }
    }
}
