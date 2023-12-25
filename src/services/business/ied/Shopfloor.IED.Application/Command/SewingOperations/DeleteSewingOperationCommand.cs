using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperations
{
    public class DeleteSewingOperationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingOperationCommandHandler : IRequestHandler<DeleteSewingOperationCommand, Response<int>>
    {
        private readonly ISewingOperationRepository _repository;
        public DeleteSewingOperationCommandHandler(ISewingOperationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingOperationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingOperation Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
