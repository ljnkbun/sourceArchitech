using MediatR;
using Microsoft.Extensions.Options;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Master.Application.Settings;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Lines
{
    public class UpdateLineCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateLineCommandHandler : IRequestHandler<UpdateLineCommand, Response<int>>
    {
        private readonly ILineRepository _repository;
        private readonly MassTransit.IPublishEndpoint _publishEndpoint;
        private readonly CalculateFactoryCapacityApiSettings _settings;
        public UpdateLineCommandHandler(ILineRepository repository,
            MassTransit.IPublishEndpoint publishEndpoint,
            IOptions<CalculateFactoryCapacityApiSettings> setting)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _settings = setting.Value;
        }
        public async Task<Response<int>> Handle(UpdateLineCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Line Not Found.");
            var oldWorker = entity.Worker;

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Worker = command.Worker;
            entity.WFXLineId = command.WFXLineId;
            entity.ProcessId = command.ProcessId;
            entity.FactoryId = command.FactoryId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);

            if(command.Worker != null && command.Worker != oldWorker)
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
