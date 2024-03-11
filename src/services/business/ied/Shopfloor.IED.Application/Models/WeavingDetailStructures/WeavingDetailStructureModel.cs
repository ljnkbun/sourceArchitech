using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.WeavingDetailStructures
{
    public class WeavingDetailStructureModel : BaseModel
    {
        public int WeavingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public StructureType StructureType { get; set; }
        public int Denting { get; set; }
        public int DentSplit { get; set; }
        public int Total { get; set; }
        public bool Deleted { get; set; }
    }
}
