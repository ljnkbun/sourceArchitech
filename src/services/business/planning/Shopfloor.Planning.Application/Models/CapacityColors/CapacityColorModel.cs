using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.CapacityColors
{
    public class CapacityColorModel : BaseModel
    {
        public string Color { get; set; }
		public decimal? FromRange { get; set; }
		public decimal? ToRange { get; set; }
    }
}
