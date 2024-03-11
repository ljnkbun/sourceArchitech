using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Production.Application.Parameters.Attachments
{
    public class AttachmentParameter : RequestParameter
    {
        public int? ProductionOutputId { get; set; }
        public int? DefectCapturing100PointsId { get; set; }
        public int? DefectCapturing4PointsId { get; set; }
        public int? DefectCapturingStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
    }
}
