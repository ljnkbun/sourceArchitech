using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.DyeingFiles
{
    public class DyeingFileModel : BaseModel
    {
        public int DyeingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
}
