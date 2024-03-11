namespace Shopfloor.EventBus.Models.Requests.Masters.Machines
{
    public class GetMachinesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Remarks { get; set; }
        public decimal? Capacity { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }
    }
}
