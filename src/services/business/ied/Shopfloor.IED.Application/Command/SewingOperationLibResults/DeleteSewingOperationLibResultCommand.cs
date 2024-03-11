using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationLibResults
{
    public class DeleteSewingOperationLibResultCommand : IRequest<Response<int>>
    {
        public int SewingOperationLibId { get; set; }
    }
    public class DeleteSewingOperationLibResultCommandHandler : IRequestHandler<DeleteSewingOperationLibResultCommand, Response<int>>
    {
        private readonly ISewingOperationLibResultRepository _repository;
        public DeleteSewingOperationLibResultCommandHandler(ISewingOperationLibResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingOperationLibResultCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetSewingOperationLibResultsAsync(command.SewingOperationLibId);
            if (entities == null) return new($"SewingOperationLibResult Not Found.");
            await _repository.DeleteRangeAsync(entities);
            return new Response<int>(command.SewingOperationLibId);
        }
    }
}
