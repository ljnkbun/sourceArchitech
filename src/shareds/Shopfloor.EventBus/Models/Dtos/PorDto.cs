using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.EventBus.Models.Dtos
{
    public class GetPorSyncResponse
    {
        public List<GetWfxPorResponse> Data { get; set; }
    }

    public class PorDto
    {
        public string ProductionOrderNo { get; set; }
        public int ProductionOrderID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string UserGroup { get; set; }
        public string OCSRServiceNo { get; set; }
        public int OrderID { get; set; }
        public string OCStatus { get; set; }
        public string OrderType { get; set; }
        public string ParentOCNo { get; set; }
        public string Buyer { get; set; }
        public string BuyerOrderRef { get; set; }
        public string GarmentDelDate { get; set; }
        public string BOMNo { get; set; }
        public int BOMID { get; set; }
        public string Category { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string BuyerStyleRef { get; set; }
        public string Season { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public int ArticleID { get; set; }
        public string UOM { get; set; }
        public string Process { get; set; }
        public int ProcessID { get; set; }
        public string MaterialSyncDate { get; set; }
        public double TotalQty { get; set; }
        public List<PorDetail> ColorSizeDetails { get; set; }
    }

    public class PorDetail
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string Size { get; set; }
        public double OrderedQty { get; set; }
        public int AllocatedQty { get; set; }
        public int Qtytobeallocated { get; set; }
    }
}
