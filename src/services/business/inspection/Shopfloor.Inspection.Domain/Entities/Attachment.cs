using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public int? InspectionId { get; set; }
        public int? Inpection4PointSysId { get; set; }
        public int? Inpection100PointSysId { get; set; }
        public int? InpectionTCStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
        public virtual Inspection Inspection { get; set; }
        public virtual Inpection4PointSys Inpection4PointSys { get; set; }
        public virtual Inpection100PointSys Inpection100PointSys { get; set; }
        public virtual InpectionTCStandard InpectionTCStandard { get; set; }
    }
}
