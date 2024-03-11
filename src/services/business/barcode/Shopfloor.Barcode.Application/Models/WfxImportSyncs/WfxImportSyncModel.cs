namespace Shopfloor.Barcode.Application.Models.WfxImportSyncs
{
    public class WfxImportSyncModel
    {
        public WfxImportSyncModel()
        {
            ListRoll = new List<Roll>();
        }
        public string ReceiptDocumentID { get; set; }
        public string OrderType { get; set; }
        public string OrderRefNum { get; set; }
        public string SupplierName { get; set; }
        public string WFXArticleCode { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public virtual List<Roll> ListRoll { get; set; }
    }

    public class Roll
    {
        public string ReceiptRollID { get; set; }
        public string ReceiptRollBarcode { get; set; }
        public string ReceiptRollNo { get; set; }
        public decimal? ReceiptRoll { get; set; }
        public decimal? TotalReceiptRoll { get; set; }
        public decimal? TotalRoll { get; set; }
        public string ReceiptRollShadeRef { get; set; }
        public string ReceiptRollSORef { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public string MovementUOM { get; set; }
        public string POUOM { get; set; }
        public string ReceiptRollNotes { get; set; }
        public string SupplierShade { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

