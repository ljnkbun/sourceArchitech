using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Buyers;
using Shopfloor.EventBus.Models.Responses.Masters.Buyers;
using Shopfloor.Master.Application.Query.Buyers;

namespace Shopfloor.Master.Api.Consumers.Requests.Buyers
{
    public class GetBuyerByIdRequestConsumer : IConsumer<GetBuyerByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetBuyerByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetBuyerByIdRequest> context)
        {
            Log.Warning($"GetBuyerByIdRequestConsumer: request={context.Message.ToJson()}");

            var buyers = await _mediator.Send(new GetBuyerQuery() { Id = context.Message.Id });
            if (buyers?.Data == null) await context.RespondAsync(null);
            var response = new GetBuyerByIdResponse
            {
                Id = buyers.Data.Id,
                WFXBuyerId = buyers.Data.WFXBuyerId,
                Name = buyers.Data.Name,
                IsActive = buyers.Data.IsActive
            };
            Log.Information($"GetBuyerByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}