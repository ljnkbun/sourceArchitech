using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRoutings
{
    public class DeleteSewingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingRoutingCommandHandler : IRequestHandler<DeleteSewingRoutingCommand, Response<int>>
    {
        private readonly ISewingRoutingRepository _repository;
        public DeleteSewingRoutingCommandHandler(ISewingRoutingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingRouting Not Found (Id:{command.Id}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
