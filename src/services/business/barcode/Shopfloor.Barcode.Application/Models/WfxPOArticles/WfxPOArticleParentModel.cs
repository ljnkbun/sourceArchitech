using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.WfxPOArticles
{

    public class WfxPOArticleParentModel : BaseModel
    {
        public WfxPOArticleParentModel()
        {
            WfxPOArticleChildModels = new List<WfxPOArticleChildModel>();
        }
        public string OrderType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string MaterialType { get; set; }
        public string ProductGroup { get; set; }
        public string OCNum { get; set; }
        public string UOM { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public decimal? Units { get; set; }
        public string SupplierRef { get; set; }
        public string SupplierName { get; set; }
        public string SupplierShortName { get; set; }
        public string SupplierCompanyID { get; set; }
        public string OrderCompany { get; set; }
        public string BuyerStyleNum { get; set; }
        public ICollection<WfxPOArticleChildModel> WfxPOArticleChildModels { get; set; }
    }

}
