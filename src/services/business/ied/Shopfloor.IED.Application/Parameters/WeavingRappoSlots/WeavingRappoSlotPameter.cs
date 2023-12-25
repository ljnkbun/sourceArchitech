using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingRappoSlots
{
    public class WeavingRappoSlotParameter : RequestParameter
    {
        public int? WeavingRappoId { get; set; }
        public int? GroupNum { get; set; }
        public SlotType? SlotType { get; set; }
        public int? YarnOfBackground { get; set; }
        public int? NumOfRappo { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public bool? Deleted { get; set; }
    }
}
