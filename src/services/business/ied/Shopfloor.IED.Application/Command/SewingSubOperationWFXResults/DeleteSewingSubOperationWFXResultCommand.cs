using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubOperationWFXResults
{
    public class DeleteSewingSubOperationWFXResultCommand : IRequest<Response<int>>
    {
        public int sewingSubOperationWFXId { get; set; }
    }
    public class DeleteSewingSubOperationWFXResultCommandHandler : IRequestHandler<DeleteSewingSubOperationWFXResultCommand, Response<int>>
    {
        private readonly ISewingSubOperationWFXResultRepository _repository;
        public DeleteSewingSubOperationWFXResultCommandHandler(ISewingSubOperationWFXResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingSubOperationWFXResultCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetSewingSubOperationWFXResultsAsync(command.sewingSubOperationWFXId);
            if (entities == null) throw new ApiException($"SewingSubOperationWFXResult Not Found.");
            await _repository.DeleteRangeAsync(entities);
            return new Response<int>(command.sewingSubOperationWFXId);
        }
    }
}
