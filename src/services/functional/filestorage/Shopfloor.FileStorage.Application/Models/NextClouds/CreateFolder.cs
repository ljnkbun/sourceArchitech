namespace Shopfloor.FileStorage.Models
{
    public class CreateFolder
    {
        public string FolderName {  get; set; }
        public string FolderPath { get; set; }

        public CreateFolder(string folderName, string folderPath)
        {
            FolderName = folderName;
            FolderPath = folderPath;
        }
    }
}
