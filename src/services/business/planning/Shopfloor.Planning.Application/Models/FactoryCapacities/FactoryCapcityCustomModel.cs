namespace Shopfloor.Planning.Application.Models.FactoryCapacities
{
    public class FactoryCapcityCustomModel
    {
        public FactoryCapcityCustomModel()
        {
            FactoryCapacities = new List<FactoryCapacityDetail>();
        }
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int? PlanningGroupFactoryId { get; set; }
        public List<FactoryCapacityDetail> FactoryCapacities { get; set; }
    }
}
