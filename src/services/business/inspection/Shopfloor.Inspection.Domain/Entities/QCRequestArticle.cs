using NPOI.OOXML.XSSF.UserModel;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCRequestArticle : BaseEntity
    {

        public int QCRequestId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Shade { get; set; }
        public string Lot { get; set; }
        public string StyleNo { get; set; }
        public string StyleName { get; set; }
        public string Season { get; set; }
        public string Buyer { get; set; }
        public string FPONo { get; set; }
        public string Location { get; set; }
        public string UOM { get; set; }
        public string OCNo { get; set; }
        public string GRNNo { get; set; }
        public string PONo { get; set; }
        public DateTime? GRNDate { get; set; }
        public decimal RequestedQty { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public decimal QCReleasedQty { get; set; }
        public decimal GRNQty { get; set; }
		public string JobOrderNo { get; set; }
		public string BatchNo { get; set; }
		public string Line { get; set; }
		public string Machine { get; set; }
		public decimal PlannedQty { get; set; }
		public decimal? MadeQty { get; set; }
		public decimal? BalanceQty { get; set; }
		public decimal WeightKg {  get; set; }
		public decimal WidghtKg {  get; set; }
		public decimal Length { get; set; }
		public decimal RollQty { get; set; }
        public virtual QCRequest QCRequest { get; set; }
        public virtual Inspection Inspection { get; set; }
        public virtual Inpection100PointSys Inpection100PointSys { get; set; }
        public virtual InpectionTCStandard InpectionTCStandard { get; set; }
        public virtual Inpection4PointSys Inpection4PointSys { get; set; }
    }
}
