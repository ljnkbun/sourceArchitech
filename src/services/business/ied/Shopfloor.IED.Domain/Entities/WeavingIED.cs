namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingIED : DivisionIED
    {
        public WeavingIED()
        {
            WeavingRoutings = new HashSet<WeavingRouting>();
            WeavingYarns = new HashSet<WeavingYarn>();
            WeavingDetailStructures = new HashSet<WeavingDetailStructure>();
            WeavingFiles = new HashSet<WeavingFile>();
        }
        public int? RequestTypeId { get; set; }
        public virtual RequestArticleOutput RequestArticleOutput { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual ICollection<WeavingRouting> WeavingRoutings { get; set; }
        public virtual ICollection<WeavingYarn> WeavingYarns { get; set; }
        public virtual WeavingRappo WeavingRappo { get; set; }
        public virtual WeavingRusticFabricSpec WeavingRusticFabricSpec { get; set; }
        public virtual ICollection<WeavingDetailStructure> WeavingDetailStructures { get; set; }
        public virtual WeavingReportSetting WeavingReportSetting { get; set; }
        public virtual ICollection<WeavingFile> WeavingFiles { get; set; }
    }
}
