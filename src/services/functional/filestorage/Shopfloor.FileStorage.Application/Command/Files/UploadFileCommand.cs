using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Models.Responses;
using Shopfloor.FileStorage.Application.Extensions;
using Shopfloor.FileStorage.Application.Interfaces;
using Shopfloor.FileStorage.Application.Models;
using Shopfloor.FileStorage.Domain.Interfaces;
using Shopfloor.FileStorage.Models;

namespace Shopfloor.FileStorage.Application.Command.Files
{
    public class UploadFileCommand : IRequest<Response<UploadFileModel>>
    {
        public string Folder { get; set; }
        public IFormFile File { get; set; }
    }
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Response<UploadFileModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository _repository;
        private readonly INextCloudService _nextCloudService;
        public UploadFileCommandHandler(IMapper mapper,
            IFileRepository repository,
            INextCloudService nextCloudService)
        {
            _mapper = mapper;
            _repository = repository;
            _nextCloudService = nextCloudService;
        }
        public async Task<Response<UploadFileModel>> Handle(UploadFileCommand command, CancellationToken cancellationToken)
        {
            var uploadFile = new UploadFile(command.File.FileName, command.Folder, command.File);
            if (await _nextCloudService.UploadAsync(uploadFile, cancellationToken))
            {
                var file = new Domain.Entities.File(
                    command.File.FileName,
                    command.File.GetExtension(),
                    command.File.Length,
                    command.Folder);
                await _repository.AddAsync(file);
                return new Response<UploadFileModel>(_mapper.Map<UploadFileModel>(file));
            }
            return new Response<UploadFileModel>("Upload failed.");
        }
    }
}
