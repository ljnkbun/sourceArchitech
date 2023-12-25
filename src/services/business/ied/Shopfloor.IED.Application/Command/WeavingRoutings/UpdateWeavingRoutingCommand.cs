using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRoutings
{
    public class UpdateWeavingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingOperation { get; set; }
        public string MachineType { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingRoutingCommandHandler : IRequestHandler<UpdateWeavingRoutingCommand, Response<int>>
    {
        private readonly IWeavingRoutingRepository _repository;
        public UpdateWeavingRoutingCommandHandler(IWeavingRoutingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingRouting Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.WeavingProcess = command.WeavingProcess;
            entity.WeavingOperation = command.WeavingOperation; 
            entity.MachineType = command.MachineType;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
