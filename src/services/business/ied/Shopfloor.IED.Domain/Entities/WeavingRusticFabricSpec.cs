using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRusticFabricSpec : BaseEntity
    {
        public int WeavingArticleId { get; set; }
        public int LineNumber { get; set; }
        public string BackgroundType { get; set; }
        public decimal BackgroundLoomFrame { get; set; }
        public string BorderType { get; set; }
        public decimal BorderLoomFrame { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGM2 { get; set; }
        public decimal VerticalShrinkage { get; set; }
        public decimal HorizontalShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal RPM { get; set; }
        public decimal CombNum { get; set; }
        public decimal CombSize { get; set; }
        public decimal VerticalDensity { get; set; }
        public decimal HorizontalDensity { get; set; }
        public decimal RusticSize { get; set; }
        public decimal HorizontalDensitySetting { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingArticle WeavingArticle { get; set; }
    }
}
