namespace Shopfloor.IED.Domain.Entities
{
    public class SewingIED : DivisionIED
    {
        public SewingIED()
        {
            SewingRoutings = new HashSet<SewingRouting>();
            SewingFiles = new HashSet<SewingFile>();
        }
        public string StyleRef { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal FactoryTime { get; set; }
        public decimal LabourCostOp { get; set; }
        public decimal LabourCostFactory { get; set; }
        public decimal FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal LabourCostFactoryIncludingOverhead { get; set; }
        public virtual RequestArticleOutput RequestArticleOutput { get; set; }
        public virtual ICollection<SewingRouting> SewingRoutings { get; set; }
        public virtual ICollection<SewingFile> SewingFiles { get; set; }
    }
}
