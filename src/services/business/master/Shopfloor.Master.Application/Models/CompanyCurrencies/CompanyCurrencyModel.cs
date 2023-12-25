using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Models.CompanyCurrencies
{
    public class CompanyCurrencyModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
