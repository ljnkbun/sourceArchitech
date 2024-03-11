namespace Shopfloor.IED.Domain.Entities
{
    public class KnittingIED : DivisionIED
    {
        public KnittingIED()
        {
            KnittingYarns = new HashSet<KnittingYarn>();
            KnittingRoutings = new HashSet<KnittingRouting>();
            KnittingGreiges = new HashSet<KnittingGreige>();
            KnittingFiles = new HashSet<KnittingFile>();
        }
        public string Remark { get; set; }
        public virtual ICollection<KnittingYarn> KnittingYarns { get; set; }
        public virtual ICollection<KnittingRouting> KnittingRoutings { get; set; }
        public virtual ICollection<KnittingGreige> KnittingGreiges { get; set; }
        public virtual RequestArticleOutput RequestArticleOutput { get; set; }
        public virtual ICollection<KnittingFile> KnittingFiles { get; set; }
    }
}
