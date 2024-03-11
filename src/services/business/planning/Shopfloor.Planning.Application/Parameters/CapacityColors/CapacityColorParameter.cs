using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.CapacityColors
{
    public class CapacityColorParameter : RequestParameter
    {
        public string Color { get; set; }
		public decimal? FromRange { get; set; }
		public decimal? ToRange { get; set; }
    }
}
