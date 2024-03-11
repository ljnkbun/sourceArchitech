using Shopfloor.Core.Models.Entities;

namespace Shopfloor.FileStorage.Application.Models
{
    public class FileModel : BaseModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Folder { get; set; }
    }
}
