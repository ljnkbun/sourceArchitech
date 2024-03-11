namespace Shopfloor.EventBus.Models.Responses
{
    public class GetWfxGDIResponse
    {
        public List<GetWfxGDIDto> Data { get; set; }
    }

    public class GetWfxGDIDto
    {
        public string GDINum { get; set; }
        public DateTime? GDICreationDate => OrderCreationDate;
        public string GDIType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string WFXArticleCode { get; set; }
        public string WFXArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string RollNo { get; set; }
        public string RollBarcode { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string RollOCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public decimal? GDIPendingUnits { get; set; }
        public decimal? RollUnits { get; set; }

    }

}
