using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Shopfloor.Core.Exceptions;
using Shopfloor.FileStorage.Application.Interfaces;
using Shopfloor.FileStorage.Domain.Interfaces;
using Shopfloor.FileStorage.Models;

namespace Shopfloor.FileStorage.Application.Command.Files
{
    public class DownloadFileByIdCommand : IRequest<FileContentResult>
    {
        public int Id { get; set; }
    }
    public class DownloadFileByIdCommandHandler : IRequestHandler<DownloadFileByIdCommand, FileContentResult>
    {
        private readonly IFileRepository _repository;
        private readonly INextCloudService _nextCloudService;
        public DownloadFileByIdCommandHandler(IFileRepository repository,
            INextCloudService nextCloudService)
        {
            _repository = repository;
            _nextCloudService = nextCloudService;
        }
        public async Task<FileContentResult> Handle(DownloadFileByIdCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id)
                ?? throw new ApiException($"File Not Found (Id:{command.Id}).");
            var download = new DownloadFile(entity.Name, entity.Path);

            var bytes = await _nextCloudService.DownloadAsync(download, cancellationToken);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(entity.Name, out var contentType))
                contentType = "application/octet-stream";

            return new FileContentResult(bytes, contentType)
            {
                FileDownloadName = entity.Name
            };
        }
    }
}
