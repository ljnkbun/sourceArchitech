using Shopfloor.Material.Application.Models.PriceListDetailColors;
using Shopfloor.Material.Application.Models.PriceListDetailSizes;

namespace Shopfloor.Material.Application.Models.PriceListDetails
{
    public class PriceListDetailModel
    {
        public int PriceListId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialCode { get; set; }

        public string Uom { get; set; }

        public string DeliveryTerm { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public ICollection<PriceListDetailColorModel> PriceListDetailColors { get; set; }

        public ICollection<PriceListDetailSizeModel> PriceListDetailSizes { get; set; }
    }
}