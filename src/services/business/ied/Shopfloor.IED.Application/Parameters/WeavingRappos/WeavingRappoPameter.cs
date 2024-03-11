using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.WeavingRappos
{
    public class WeavingRappoParameter : RequestParameter
    {
        public int? WeavingIEDId { get; set; }
        public int? Line { get; set; }
        public int? WarpPerMarginDentSplit { get; set; }
        public int? WarpPerContentDentSplit { get; set; }
        public int? TotalRappo { get; set; }
        public int? AdditionYarn { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public string DrawingComment { get; set; }
        public bool? Deleted { get; set; }
    }
}
