using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.PricePers
{
    public class PricePerParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
