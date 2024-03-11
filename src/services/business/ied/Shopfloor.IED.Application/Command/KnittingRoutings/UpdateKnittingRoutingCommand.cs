using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingRoutings
{
    public class UpdateKnittingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public string KnittingProcess { get; set; }
        public string KnittingProcessCode { get; set; }
        public string KnittingOperationCode { get; set; }
        public string KnittingOperation { get; set; }
        public int MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingRoutingCommandHandler : IRequestHandler<UpdateKnittingRoutingCommand, Response<int>>
    {
        private readonly IKnittingRoutingRepository _repository;
        public UpdateKnittingRoutingCommandHandler(IKnittingRoutingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingRouting Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.KnittingProcess = command.KnittingProcess;
            entity.KnittingOperation = command.KnittingOperation;
            entity.MachineTypeId = command.MachineTypeId;
            entity.MachineTypeName = command.MachineTypeName;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
