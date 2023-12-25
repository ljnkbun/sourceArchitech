using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Gauges
{
    public class GaugeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
