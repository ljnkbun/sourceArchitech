using Microsoft.AspNetCore.Http;

namespace Shopfloor.FileStorage.Models
{
    public class UploadFile
    {
        public string FileName {  get; set; }
        public string FilePath { get; set; }
        public IFormFile File { get; set; }

        public UploadFile(string fileName, string filePath, IFormFile file)
        {
            FileName = fileName;
            FilePath = filePath;
            File = file;
        }
    }
}
