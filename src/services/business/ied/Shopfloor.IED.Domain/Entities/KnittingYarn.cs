using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class KnittingYarn : BaseEntity
    {
        public int KnittingIEDId { get; set; }
        public int LineNumber { get; set; }
        public int WFXYarnId { get; set; }
        public string YarnName { get; set; }
        public string YarnCode { get; set; }
        public string Color { get; set; }
        public decimal YarnRatio { get; set; }
        public decimal Weight { get; set; }
        public decimal Wastage { get; set; }
        public KnittingIED KnittingIED { get; set; }
    }
}
