namespace Shopfloor.Ambassador.Application.Models
{
    public class WfxExportSyncResponse
    {
        public WfxExportSyncResponse()
        {
            Data = new List<WFXAPIGeneratePLTData>();
        }
        public List<WFXAPIGeneratePLTData> Data { get; set; }
    }

    public class WFXAPIGeneratePLTData
    {
        public WFXAPIGeneratePLTData()
        {
        }
        public string GDINum { get; set; }
        public string GDIType { get; set; }
        public string OrderRefNum { get; set; }
        public string WFXArticleCode { get; set; }
        public string WFXArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string RollNo { get; set; }
        public string RollBarCode { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public string WareHouse { get; set; }
        public decimal? RollUnits { get; set; }

    }

}

