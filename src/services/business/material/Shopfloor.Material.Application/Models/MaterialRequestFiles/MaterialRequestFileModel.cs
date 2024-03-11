using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.MaterialRequestFiles
{
    public class MaterialRequestFileModel : BaseModel
    {
        public int MaterialRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }
}