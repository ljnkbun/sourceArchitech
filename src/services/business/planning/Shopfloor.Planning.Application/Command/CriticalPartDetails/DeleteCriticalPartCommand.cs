using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.CriticalParts
{
    public class DeleteCriticalPartCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCriticalPartCommandHandler : IRequestHandler<DeleteCriticalPartCommand, Response<int>>
    {
        private readonly ICriticalPartRepository _repository;
        public DeleteCriticalPartCommandHandler(ICriticalPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteCriticalPartCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"CriticalPart Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
