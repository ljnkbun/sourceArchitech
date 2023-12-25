using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.Zones
{
    public class ZoneParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? ZoneSalary { get; set; }

    }
}
