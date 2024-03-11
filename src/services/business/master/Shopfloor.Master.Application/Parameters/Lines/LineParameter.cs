using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Lines
{
    public class LineParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
    }
}
