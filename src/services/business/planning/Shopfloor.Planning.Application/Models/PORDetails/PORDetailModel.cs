using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.PORDetails
{
    public class PORDetailModel : BaseModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public int PORId { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? Type { get; set; }
    }
}
