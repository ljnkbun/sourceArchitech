using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Buyers
{
    public class BuyerParameter : RequestParameter
    {
        public string WFXBuyerId { get; set; }

        public string Name { get; set; }
    }
}
