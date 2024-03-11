using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.FPPODetails
{
    public class FPPODetailModel : BaseModel
    {
        public int FPPOId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Quantity { get; set; }
    }
}
