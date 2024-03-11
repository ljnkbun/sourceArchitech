using Shopfloor.IED.Application.Models.WeavingRappoMarks;
using Shopfloor.IED.Application.Models.WeavingRappoMatrics;

namespace Shopfloor.IED.Application.Models.WeavingRappos
{
    public class UpdateCreateWeavingRappoModel
    {
        public int Id { get; set; }
        public int WeavingIEDId { get; set; }
        public int Line { get; set; }
        public int WarpPerMarginDentSplit { get; set; }
        public int WarpPerContentDentSplit { get; set; }
        public int TotalRappo { get; set; }
        public int AdditionYarn { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public string DrawingComment { get; set; }
        public IEnumerable<UpdateCreateWeavingRappoMarkModel> WeavingRappoMarks { get; set; }
        public IEnumerable<UpdateCreateWeavingRappoMatricModel> WeavingRappoMatrics { get; set; }
    }
}