using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.PlanningGroupFactories
{
    public class PlanningGroupFactoryModel : BaseModel
    {
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }
    }
}
