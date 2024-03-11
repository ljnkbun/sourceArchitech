using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public int? ProductionOutputId { get; set; }
        public int? DefectCapturing100PointsId { get; set; }
        public int? DefectCapturing4PointsId { get; set; }
        public int? DefectCapturingStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
        public virtual ProductionOutput ProductionOutput { get; set; }
        public virtual DefectCapturing100Points DefectCapturing100Points { get; set; }
        public virtual DefectCapturing4Points DefectCapturing4Points { get; set; }
        public virtual DefectCapturingStandard DefectCapturingStandard { get; set; }
    }
}
