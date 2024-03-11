using Shopfloor.Core.Models.Parameters;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Parameters.PORDetails
{
    public class PORDetailParameter : RequestParameter
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public int? PORId { get; set; }
        public PorType? Type { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PORStatus? Status { get; set; }
    }
}
