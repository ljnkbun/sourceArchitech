namespace Shopfloor.Planning.Application
{
    public class JobSettings
    {
        public FactoryCapacityJob FactoryCapacity { get; set; }
    }

    public class FactoryCapacityJob
    {
        public int Month { get; set; }
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
}
