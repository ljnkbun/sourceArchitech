using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Planning.Application.Command.FactoryCapacities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Api.Consumers.Messages
{
    public class CalculateFactoryCapacityMessageConsumer : IConsumer<CalculateFactoryCapacityMessage>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly CancellationToken _cancellationToken;

        public CalculateFactoryCapacityMessageConsumer(
            IServiceProvider serviceProvider,
            IBackgroundTaskQueue taskQueue,
            IHostApplicationLifetime applicationLifetime,
            IMediator mediator)
        {
            var scope = serviceProvider.CreateScope();
            _taskQueue = taskQueue;
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        #endregion Initialization

        #region Consumer

        public async Task Consume(ConsumeContext<CalculateFactoryCapacityMessage> context)
        {
            Log.Warning($"CalculateFactoryCapacityMessageConsumer: item={context.Message.ToJson()}");

            try
            {
                await _taskQueue.QueueBackgroundWorkItemAsync(
                    ct => QueueFactoryCapacityCalculationAsync(
                        context.Message.FromDate,
                        context.Message.ToDate));
            }
            catch (Exception e)
            {
                Log.Error(e, "CalculateFactoryCapacityMessageConsumer Throw Exception !!!");
            }
        }

        #endregion

        #region Private Methods

        private async ValueTask QueueFactoryCapacityCalculationAsync(
            DateTime fromDate, DateTime toDate)
        {
            var response = await _mediator.Send(new CalculateFactoryCapacitiesCommand
            {
                FromDate = fromDate,
                ToDate = toDate
            }, _cancellationToken);

            if (response?.Data == true)
                Log.Information($"CalculateFactoryCapacityMessageConsumer Successed: Date={fromDate} - {toDate}");
            else
                Log.Information($"CalculateFactoryCapacityMessageConsumer Failed");
        }

        #endregion
    }
}
