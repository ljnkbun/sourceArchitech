using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingRoutings
{
    public class UpdateDyeingRoutingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int DyeingIEDId { get; set; }

        public int LineNumber { get; set; }

        public string DyeingProcess { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string DyeingOperation { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal Efficiency { get; set; }

        public decimal MachineTime { get; set; }

        public decimal Temperature { get; set; }

        public decimal OperationTime { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateDyeingRoutingCommandHandler : IRequestHandler<UpdateDyeingRoutingCommand, Response<int>>
    {
        private readonly IDyeingRoutingRepository _repository;

        public UpdateDyeingRoutingCommandHandler(IDyeingRoutingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingRoutingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DyeingRouting Not Found.");

            entity.DyeingIEDId = command.DyeingIEDId;
            entity.LineNumber = command.LineNumber;
            entity.DyeingProcess = command.DyeingProcess;
            entity.IsActive = command.IsActive;
            entity.DyeingOperation = command.DyeingOperation;
            entity.MachineCode = command.MachineCode;
            entity.MachineName = command.MachineName;
            entity.Efficiency = command.Efficiency;
            entity.MachineTime = command.MachineTime;
            entity.Temperature = command.Temperature;
            entity.OperationTime = command.OperationTime;
            entity.DyeingProcessCode = command.DyeingProcessCode;
            entity.DyeingOperationCode = command.DyeingOperationCode;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}