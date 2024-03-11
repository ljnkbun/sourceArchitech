using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.StripFactoryDetails
{
    public class CalculateStripFactoryDetailModel : BaseModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int StripFactoryId { get; set; }
    }
}
