using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubOperationLibraries
{
    public class DeleteSubOperationLibraryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSubOperationLibraryCommandHandler : IRequestHandler<DeleteSubOperationLibraryCommand, Response<int>>
    {
        private readonly ISubOperationLibraryRepository _repository;
        public DeleteSubOperationLibraryCommandHandler(ISubOperationLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSubOperationLibraryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SubOperationLibrary Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
