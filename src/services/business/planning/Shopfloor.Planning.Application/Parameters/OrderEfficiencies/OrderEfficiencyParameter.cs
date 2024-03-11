using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.OrderEfficiencies
{
    public class OrderEfficiencyParameter : RequestParameter
    {
        public string OCNo { get; set; }
        public decimal EfficiencyValue { get; set; }
    }
}
