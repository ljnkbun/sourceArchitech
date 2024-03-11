using Shopfloor.Core.Models.Entities;

namespace Shopfloor.FileStorage.Domain.Entities
{
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Folder { get; set; }

        public File() { }

        public File(string name, string extension, long size, string folder)
        {
            Name = name;
            Path = $"{folder}/{name}";
            Extension = extension;
            Size = size;
            Folder = folder;
        }
    }
}
