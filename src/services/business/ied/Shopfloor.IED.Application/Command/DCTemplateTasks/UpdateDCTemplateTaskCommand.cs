using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplateTask
{
    public class UpdateDCTemplateTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DCTemplateId { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOpreationId { get; set; }
        public string DyeingOpreationName { get; set; }
        public int LineNumber { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string Temperature { get; set; }
        public int Minute { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDCTemplateTaskCommandHandler : IRequestHandler<UpdateDCTemplateTaskCommand, Response<int>>
    {
        private readonly IDCTemplateTaskRepository _repository;

        public UpdateDCTemplateTaskCommandHandler(IDCTemplateTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDCTemplateTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DCTemplateTask Not Found.");

            entity.DCTemplateId = command.DCTemplateId;
            entity.DyeingProcessId = command.DyeingProcessId;
            entity.DyeingProcessName = command.DyeingProcessName;
            entity.DyeingOpreationId = command.DyeingOpreationId;
            entity.DyeingOpreationName = command.DyeingOpreationName;
            entity.LineNumber = command.LineNumber;
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