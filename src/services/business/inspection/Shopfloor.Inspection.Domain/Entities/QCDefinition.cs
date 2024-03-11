using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCDefinition : BaseMasterEntity
    {
        public QCDefinition()
        {
            QCDefinitionDefects = new HashSet<QCDefinitionDefect>();
        }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal AcceptanceValue { get; set; }
		public int ConversionId { get; set; }
        public virtual Conversion Conversion { get; set; }
        public virtual ICollection<QCDefinitionDefect> QCDefinitionDefects { get; set; }
        public int QCTypeId { get; set; }
        public virtual QCType QCType { get; set; }
        public decimal? PercentQC { get; set; }
        public decimal? PercentAcceptance { get; set; }
        public decimal? FixedQty { get; set; }
        public decimal? AcceptanceQty { get; set; }
        public decimal? Quantity { get; set; }
        public int? AQLVersionId { get; set; }
        public int? FourPointsSystemId { get; set; }
        public int? OneHundredPointSystemId { get; set; }
        public virtual AQLVersion AQLVersion { get; set; }
        public virtual FourPointsSystem FourPointsSystem { get; set; }
        public virtual OneHundredPointSystem OneHundredPointSystem { get; set; }
    }
}
