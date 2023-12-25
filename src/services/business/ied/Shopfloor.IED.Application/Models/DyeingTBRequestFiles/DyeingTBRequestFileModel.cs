using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.DyeingTBRequestFiles
{
    public class DyeingTBRequestFileModel : BaseModel
    {
        public int DyeingTBRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }
}