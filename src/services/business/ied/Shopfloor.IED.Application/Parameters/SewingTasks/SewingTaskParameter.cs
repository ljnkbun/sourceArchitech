using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingTasks
{
    public class SewingTaskParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal? TotalTMU { get; set; }
        public bool? Deleted { get; set; }
    }
}
