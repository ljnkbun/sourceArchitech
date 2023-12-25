using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class PriceListDetail : BaseEntity
    {
        public PriceListDetail()
        {
            PriceListDetailSizes = new HashSet<PriceListDetailSize>();
            PriceListDetailColors = new HashSet<PriceListDetailColor>();
        }

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

        public PriceList PriceList { get; set; }

        public virtual ICollection<PriceListDetailColor> PriceListDetailColors { get; set; }

        public virtual ICollection<PriceListDetailSize> PriceListDetailSizes { get; set; }
    }
}