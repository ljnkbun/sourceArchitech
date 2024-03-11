using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.FileStorage.Domain.Interfaces;

namespace Shopfloor.FileStorage.Application.Command.Files
{
    public class DeleteFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Response<int>>
    {
        private readonly IFileRepository _repository;
        public DeleteFileCommandHandler(IFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id)
                ?? throw new ApiException($"TestEntity Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
