using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingOperations
{
    public class DeleteWeavingOperationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWeavingOperationCommandHandler : IRequestHandler<DeleteWeavingOperationCommand, Response<int>>
    {
        private readonly IWeavingOperationRepository _repository;

        public DeleteWeavingOperationCommandHandler(IWeavingOperationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteWeavingOperationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingOperation Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}