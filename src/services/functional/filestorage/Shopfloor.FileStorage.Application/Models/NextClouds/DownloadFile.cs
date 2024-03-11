namespace Shopfloor.FileStorage.Models
{
    public class DownloadFile
    {
        public string FileName {  get; set; }
        public string FilePath { get; set; }

        public DownloadFile(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }
    }
}
