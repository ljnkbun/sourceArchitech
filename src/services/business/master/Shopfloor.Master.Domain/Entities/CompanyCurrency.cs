using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class CompanyCurrency : BaseMasterEntity
    {
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime? ValidFrom { get; set; }
    }
}
