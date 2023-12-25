using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProcessLibraries
{
    public class DeleteProcessLibraryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProcessLibraryCommandHandler : IRequestHandler<DeleteProcessLibraryCommand, Response<int>>
    {
        private readonly IProcessLibraryRepository _repository;
        public DeleteProcessLibraryCommandHandler(IProcessLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProcessLibraryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ProcessLibrary Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
