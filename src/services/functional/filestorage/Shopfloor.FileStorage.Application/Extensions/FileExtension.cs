using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Definations;

namespace Shopfloor.FileStorage.Application.Extensions
{
    public static class FileExtension
    {
        public static string GetExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName).ToLower();
        }
        public static FileType GetFileType(this string extension)
        {
            return extension switch
            {
                ".jpg" or ".jpeg" or ".png" => FileType.Images,
                ".mp3" => FileType.Audio,
                ".mp4" or ".avg" => FileType.Audio,
                _ => FileType.Document,
            };
        }
        public static byte[] GetBytes(this IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
        public static byte[] GetBytes(this Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
