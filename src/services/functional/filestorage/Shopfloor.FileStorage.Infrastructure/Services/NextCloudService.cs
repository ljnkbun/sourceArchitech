using Shopfloor.FileStorage.Application.Extensions;
using Shopfloor.FileStorage.Application.Interfaces;
using Shopfloor.FileStorage.Models;
using WebDAVClient;

namespace Shopfloor.FileStorage.Infrastructure.Services
{
    public class NextCloudService : INextCloudService
    {
        private readonly IClient _client;
        public NextCloudService(IClient client)
        {
            _client = client;
        }

        public async Task<bool> UploadAsync(UploadFile upload, CancellationToken cancellationToken = default)
        {
            return await _client.Upload(upload.FilePath, upload.File.OpenReadStream(), upload.FileName, cancellationToken);
        }

        public async Task<byte[]> DownloadAsync(DownloadFile download, CancellationToken cancellationToken = default)
        {
            using var stream = await _client.Download(download.FilePath, cancellationToken);
            return stream.GetBytes();
        }
    }
}
