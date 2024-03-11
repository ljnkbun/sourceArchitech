using Shopfloor.Core.Models.Parameters;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Parameters.StripFactoryDetails
{
    public class StripFactoryDetailParameter : RequestParameter
    {
        public int? PorDetailId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int? StripFactoryId { get; set; }
    }
}
