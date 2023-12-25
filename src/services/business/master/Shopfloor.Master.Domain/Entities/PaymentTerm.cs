using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class PaymentTerm : BaseMasterEntity
    {
        public int CreditDays { get; set; }
    }
}
