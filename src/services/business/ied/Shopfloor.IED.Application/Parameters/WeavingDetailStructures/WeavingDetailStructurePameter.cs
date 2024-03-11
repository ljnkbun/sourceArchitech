using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingDetailStructures
{
    public class WeavingDetailStructureParameter : RequestParameter
    {
        public int? WeavingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public StructureType? StructureType { get; set; }
        public int? Denting { get; set; }
        public int? DentSplit { get; set; }
        public int? Total { get; set; }
        public bool? Deleted { get; set; }
    }
}
