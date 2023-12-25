using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingRappos
{
    public class WeavingRappoModel : BaseModel
    {
        public int WeavingArticleId { get; set; }
        public int NumOfLine { get; set; }
        public int YarnOfBorder { get; set; }
        public int YarnOfBackground { get; set; }
        public int NumOfRappo { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public bool Deleted { get; set; }
    }
}
