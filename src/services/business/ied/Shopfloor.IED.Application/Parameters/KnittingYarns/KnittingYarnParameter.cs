using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.KnittingYarns
{
    public class KnittingYarnParameter : RequestParameter
    {
        public int? KnittingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public int? WFXYarnId { get; set; }
        public string YarnName { get; set; }
        public string YarnCode { get; set; }
        public string Color { get; set; }
        public decimal? YarnRatio { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Wastage { get; set; }
    }
}
