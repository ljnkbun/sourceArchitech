using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.CompanyCurrencies
{
    public class CompanyCurrencyParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime? ValidFrom { get; set; }
    }
}
