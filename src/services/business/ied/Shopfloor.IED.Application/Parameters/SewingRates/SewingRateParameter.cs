using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingRates
{
    public class SewingRateParameter : RequestParameter
    {
        public decimal? ExpectedQtyFrom { get; set; }
        public decimal? ExpectedQtyTo { get; set; }
        public decimal? EfficiencyRate { get; set; }
        public decimal? CMRate { get; set; }
        public string Description { get; set; }
    }
}
