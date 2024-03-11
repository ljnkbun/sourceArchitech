using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.WfxPOArticles
{
    public class WfxPOArticleMasterModel : BaseModel
    {
        public string PONo { get; set; }
        public string OrderRefNum { get; set; }
        public string POStatus { get; set; }
        public DateTime? OrderCreationDate { get; set; }

        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string OCNum { get; set; }
        public decimal? Units { get; set; }
        public string UOM { get; set; }
        public string SupplierRef { get; set; }
        public string SupplierName { get; set; }
        public string SupplierShortName { get; set; }
        public string SupplierCompanyID { get; set; }


    }

}
