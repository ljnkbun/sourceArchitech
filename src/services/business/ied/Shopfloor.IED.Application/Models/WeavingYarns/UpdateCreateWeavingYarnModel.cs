using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.WeavingYarns
{
    public class UpdateCreateWeavingYarnModel
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public YarnType YarnType { get; set; }
        public int WFXYarnId { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public decimal? YarnTotal { get; set; }
        public decimal YarnInRappo { get; set; }
        public decimal YarnRatio { get; set; }
        public decimal SizingRatio { get; set; }
        public decimal ScaleRatio { get; set; }
        public decimal ScrapRatio { get; set; }
        public decimal WastageRatio { get; set; }
        public decimal Weight { get; set; }
        public int WeavingIEDId { get; set; }
    }
}