using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.RequestDivisionFiles
{
    public class RequestDivisionFileModel : BaseModel
    {
        public int RequestDivisionId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
}
