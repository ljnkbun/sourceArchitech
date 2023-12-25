using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.PaymentTerms
{
    public class PaymentTermModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditDays { get; set; }
    }
}
