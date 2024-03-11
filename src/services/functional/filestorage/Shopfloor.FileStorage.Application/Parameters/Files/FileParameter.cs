using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.FileStorage.Application.Parameters.Files
{
    public class FileParameter : RequestParameter
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long? Size { get; set; }
        public string Folder { get; set; }
    }
}
