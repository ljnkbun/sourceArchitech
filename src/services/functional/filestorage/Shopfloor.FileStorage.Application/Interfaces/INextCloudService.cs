using Microsoft.AspNetCore.Http;
using Shopfloor.FileStorage.Models;

namespace Shopfloor.FileStorage.Application.Interfaces
{
    public interface INextCloudService
    {
        Task<bool> UploadAsync(UploadFile upload, CancellationToken cancellationToken = default);
        Task<byte[]> DownloadAsync(DownloadFile download, CancellationToken cancellationToken = default);
    }
}
