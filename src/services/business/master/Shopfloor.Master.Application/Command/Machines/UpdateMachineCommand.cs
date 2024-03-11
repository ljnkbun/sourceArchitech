using MediatR;
using Microsoft.Extensions.Options;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Master.Application.Settings;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Machines
{
    public class UpdateMachineCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Remarks { get; set; }
        public decimal? Capacity { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public bool IsActive { set; get; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }
    }
    public class UpdateMachineCommandHandler : IRequestHandler<UpdateMachineCommand, Response<int>>
    {
        private readonly IMachineRepository _repository;
        private readonly MassTransit.IPublishEndpoint _publishEndpoint;
        private readonly CalculateFactoryCapacityApiSettings _settings;
        public UpdateMachineCommandHandler(IMachineRepository repository,
            MassTransit.IPublishEndpoint publishEndpoint,
            IOptions<CalculateFactoryCapacityApiSettings> setting)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _settings = setting.Value;
        }
        public async Task<Response<int>> Handle(UpdateMachineCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Machine Not Found.");
            var oldCapacity = entity.Capacity;

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.SerialNo = command.Name;
            entity.Remarks = command.Name;
            entity.Capacity = command.Capacity;
            entity.ProcessId = command.ProcessId;
            entity.FactoryId = command.FactoryId;
            entity.Gauge = command.Gauge;
            entity.MachineDiameter = command.MachineDiameter;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);

            if (command.Capacity != null && command.Capacity != oldCapacity)
            {
                //Call calculate factory capacity
                await CallFactoryCapacity(cancellationToken);
            }

            return new Response<int>(entity.Id);
        }

        private async Task CallFactoryCapacity(CancellationToken cancellationToken)
        {
            var fDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var tDate = fDate.AddMonths(_settings.Month);
            await _publishEndpoint.Publish(new CalculateFactoryCapacityMessage()
            {
                FromDate = fDate,
                ToDate = tDate
            }, cancellationToken);
        }
    }
}
