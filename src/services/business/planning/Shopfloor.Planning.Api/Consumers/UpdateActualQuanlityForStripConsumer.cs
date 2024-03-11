using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails;

namespace Shopfloor.Planning.Api.Consumers
{
    public class UpdateActualQuanlityForStripConsumer : IConsumer<UpdateActualQuanlityForStripMessage>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public UpdateActualQuanlityForStripConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<UpdateActualQuanlityForStripMessage> context)
        {
            Log.Warning($"UpdateActualQuanlityForStripConsumer: message={context.Message.ToJson()}");

            await _mediator.Send(new UpdateActualQuanlityForStripCommand()
            {
                FPPOId = context.Message.FPPOId,
                Quantity = context.Message.Quantity,
                Date = context.Message.Date
            });
        }
    }
}
