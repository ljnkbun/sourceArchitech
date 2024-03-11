using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingRates
{
    public class SewingRateModel : BaseModel
    {
        public decimal ExpectedQtyFrom { get; set; }
        public decimal ExpectedQtyTo { get; set; }
        public decimal EfficiencyRate { get; set; }
        public decimal CMRate { get; set; }
        public string Description { get; set; }
    }
}
