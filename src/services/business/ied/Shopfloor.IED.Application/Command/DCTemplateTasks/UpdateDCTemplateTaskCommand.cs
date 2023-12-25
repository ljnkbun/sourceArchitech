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
        public int TaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
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

            if (entity == null) throw new ApiException($"DCTemplateTask Not Found.");

            entity.DCTemplateId = command.DCTemplateId;
            entity.TaskCode = command.TaskCode;
            entity.TaskName = command.TaskName;
            entity.Temperature = command.Temperature;
            entity.Minute = command.Minute;
            entity.TaskId = command.TaskId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}