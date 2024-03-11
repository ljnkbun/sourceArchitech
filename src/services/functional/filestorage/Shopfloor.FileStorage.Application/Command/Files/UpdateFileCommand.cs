using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.FileStorage.Domain.Interfaces;

namespace Shopfloor.FileStorage.Application.Command.Files
{
    public class UpdateFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Folder { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, Response<int>>
    {
        private readonly IFileRepository _repository;
        public UpdateFileCommandHandler(IFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id)
                ?? throw new ApiException($"File Not Found.");
            entity.Name = command.Name;
            entity.Path = $"{command.Folder}/{command.Name}";
            entity.Extension = command.Extension;
            entity.Size = command.Size;
            entity.Folder = command.Folder;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
