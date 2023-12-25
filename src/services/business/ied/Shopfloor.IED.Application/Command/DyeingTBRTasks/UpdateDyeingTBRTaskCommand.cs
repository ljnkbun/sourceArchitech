using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRTasks
{
    public class UpdateDyeingTBRTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DyeingTBRecipeId { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal Temperature { get; set; }
        public int Minute { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDyeingTBRTaskCommandHandler : IRequestHandler<UpdateDyeingTBRTaskCommand, Response<int>>
    {
        private readonly IDyeingTBRTaskRepository _repository;

        public UpdateDyeingTBRTaskCommandHandler(IDyeingTBRTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRTask Not Found.");

            entity.DyeingTBRecipeId = command.DyeingTBRecipeId;
            entity.DyeingOperationName = command.DyeingOperationName;
            entity.DyeingOperationId = command.DyeingOperationId;
            entity.DyeingProcessName = command.DyeingProcessName;
            entity.DyeingProcessId = command.DyeingProcessId;
            entity.MachineCode = command.MachineCode;
            entity.MachineName = command.MachineName;
            entity.Temperature = command.Temperature;
            entity.Minute = command.Minute;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}