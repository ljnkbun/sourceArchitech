using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.PriceListDetailSizes
{
    public class PriceListDetailSizeModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int PriceListDetailId { get; set; }
    }
}