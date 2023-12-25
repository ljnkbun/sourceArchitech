using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.DeliveryTerms
{
    public class DeliveryTermParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
