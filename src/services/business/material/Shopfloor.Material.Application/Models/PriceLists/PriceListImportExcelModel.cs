namespace Shopfloor.Material.Application.Models.PriceLists
{
    public class PriceListImportExcelModel
    {
        public string MaterialCode { get; set; }

        public string CategoryCode { get; set; }

        public string SupplierCode { get; set; }

        public string ArticleCode { get; set; }

        public string ColorCode { get; set; }

        public string ColorName { get; set; }

        public string SizeCode { get; set; }

        public decimal? Price { get; set; }

        public string Currency { get; set; }

        public string Uom { get; set; }

        public string DeliveryTerm { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }
    }
}