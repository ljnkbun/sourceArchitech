using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.BuyerTypes
{
    public class BuyerTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
