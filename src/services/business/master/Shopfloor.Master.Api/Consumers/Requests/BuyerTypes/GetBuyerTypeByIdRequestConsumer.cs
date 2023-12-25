using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.BuyerTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetBuyerTypeByIdRequestConsumer : IConsumer<GetBuyerTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetBuyerTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetBuyerTypeByIdRequest> context)
        {
            Log.Warning($"GetBuyerTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var buyerTypes = await _mediator.Send(new GetBuyerTypeQuery() { Id = context.Message.Id });
            if (buyerTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetBuyerTypeByIdResponse
            {
                Id = buyerTypes.Data.Id,
                Code = buyerTypes.Data.Code,
                Name = buyerTypes.Data.Name,
                IsActive = buyerTypes.Data.IsActive
            };
            Log.Information($"GetBuyerTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}