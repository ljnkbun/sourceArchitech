using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.WeavingDetailStructures
{
    public class WeavingDetailStructureModel : BaseModel
    {
        public int WeavingIEDId { get; set; }
        public StructureType StructureType { get; set; }
        public int CombString { get; set; }
        public int SlotNumber { get; set; }
        public int Total { get; set; }
        public bool Deleted { get; set; }
    }
}
