using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.PORDetails
{
    public class SplitPorDetailModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public string UOM { get; set; }
    }
}
