using Shopfloor.Planning.Application.Models.PORs;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.PORDetails
{
    public class WfxPorDetailModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public int PORId { get; set; }
        public string UOM { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }

    }
}
