using Shopfloor.Core.Models.Parameters;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Parameters.StripScheduleDetails
{
    public class StripScheduleDetailParameter : RequestParameter
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int? PorDetailId { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int? StripScheduleId { get; set; }
    }
}
