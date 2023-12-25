using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationWFXs
{
    public class DeleteSewingOperationWFXCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingOperationWFXCommandHandler : IRequestHandler<DeleteSewingOperationWFXCommand, Response<int>>
    {
        private readonly ISewingOperationWFXRepository _repository;
        public DeleteSewingOperationWFXCommandHandler(ISewingOperationWFXRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingOperationWFXCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingOperationWFX Not Found (Id:{command.Id}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
