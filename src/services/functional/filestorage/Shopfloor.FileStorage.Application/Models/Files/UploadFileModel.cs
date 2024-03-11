using Shopfloor.Core.Definations;

namespace Shopfloor.FileStorage.Application.Models
{
    public class UploadFileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public FileType FileType { get; set; }
        public long Size { get; set; }
        public string Folder { get; set; }
    }
}
