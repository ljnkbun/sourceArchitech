using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.OrderEfficiencies
{
    public class OrderEfficiencyModel : BaseModel
    {
        public string OCNo { get; set; }
        public decimal EfficiencyValue { get; set; }
    }
}
