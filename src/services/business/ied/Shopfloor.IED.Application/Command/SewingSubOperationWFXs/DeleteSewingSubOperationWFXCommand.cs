using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubOperationWFXs
{
    public class DeleteSewingSubOperationWFXCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingSubOperationWFXCommandHandler : IRequestHandler<DeleteSewingSubOperationWFXCommand, Response<int>>
    {
        private readonly ISewingSubOperationWFXRepository _repository;
        public DeleteSewingSubOperationWFXCommandHandler(ISewingSubOperationWFXRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingSubOperationWFXCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingSubOperationWFX Not Found (Id:{command.Id}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
