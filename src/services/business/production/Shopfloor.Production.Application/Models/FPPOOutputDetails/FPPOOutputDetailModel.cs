using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Application.Models.FPPOOutputDetails
{
    public class FPPOOutputDetailModel : BaseModel
    {
        public int? FPPOOutputId { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
