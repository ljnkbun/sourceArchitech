using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingDetailStructures
{
    public class WeavingDetailStructureParameter : RequestParameter
    {
        public int? WeavingIEDId { get; set; }
        public StructureType? StructureType { get; set; }
        public int? CombString { get; set; }
        public int? SlotNumber { get; set; }
        public int? Total { get; set; }
        public bool? Deleted { get; set; }
    }
}
