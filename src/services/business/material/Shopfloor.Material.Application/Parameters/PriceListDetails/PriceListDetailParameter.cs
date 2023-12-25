using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Material.Application.Parameters.PriceListDetails
{
    public class PriceListDetailParameter : RequestParameter
    {
        public int? PriceListId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialCode { get; set; }

        public string Uom { get; set; }

        public string DeliveryTerm { get; set; }

        public decimal? Price { get; set; }

        public string Currency { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }
    }
}