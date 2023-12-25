using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.DeliveryTerms;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetDeliveryTermByIdRequestConsumer : IConsumer<GetDeliveryTermByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDeliveryTermByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDeliveryTermByIdRequest> context)
        {
            Log.Warning($"GetDeliveryTermByIdRequestConsumer: request={context.Message.ToJson()}");

            var deliveryTerms = await _mediator.Send(new GetDeliveryTermQuery() { Id = context.Message.Id });
            if (deliveryTerms?.Data == null) await context.RespondAsync(null);
            var response = new GetDeliveryTermByIdResponse
            {
                Id = deliveryTerms.Data.Id,
                Code = deliveryTerms.Data.Code,
                Name = deliveryTerms.Data.Name,
                IsActive = deliveryTerms.Data.IsActive
            };
            Log.Information($"GetDeliveryTermByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}