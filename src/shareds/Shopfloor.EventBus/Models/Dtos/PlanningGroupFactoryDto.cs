namespace Shopfloor.EventBus.Models.Dtos
{
    public class PlanningGroupFactoryDto
    {
        public int Id { get; set; }
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public string ProcessName { get; set; }
    }
}
