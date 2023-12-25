using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.PaymentTerms
{
    public class PaymentTermParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CreditDays { get; set; }
    }
}
