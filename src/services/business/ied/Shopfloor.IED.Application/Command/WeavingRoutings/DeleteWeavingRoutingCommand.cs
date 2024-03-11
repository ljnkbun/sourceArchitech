using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRoutings
{
    public class DeleteWeavingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWeavingRoutingCommandHandler : IRequestHandler<DeleteWeavingRoutingCommand, Response<int>>
    {
        private readonly IWeavingRoutingRepository _repository;

        public DeleteWeavingRoutingCommandHandler(IWeavingRoutingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteWeavingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingRouting Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}