using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.Attachments
{
    public class AttachmentModel : BaseModel
    {
        public int? InspectionId { get; set; }
        public int? Inpection4PointSysId { get; set; }
        public int? Inpection100PointSysId { get; set; }
        public int? InpectionTCStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType? FileType { get; set; }
    }
}
