using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.MOQMSQRoudingOptionItems
{
    public class MOQMSQRoudingOptionItemModel : BaseModel
    {
        public int MaterialRequestId { get; set; }

        public string Type { get; set; }

        public decimal From { get; set; }

        public decimal To { get; set; }

        public decimal Qty { get; set; }
    }
}