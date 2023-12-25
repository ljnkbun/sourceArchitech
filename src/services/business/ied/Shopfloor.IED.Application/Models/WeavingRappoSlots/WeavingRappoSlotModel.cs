using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.WeavingRappoSlots
{
    public class WeavingRappoSlotModel : BaseModel
    {
        public int WeavingRappoId { get; set; }
        public int GroupNum { get; set; }
        public SlotType SlotType { get; set; }
        public int YarnOfBackground { get; set; }
        public int NumOfRappo { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public bool Deleted { get; set; }
    }
}
