using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.PricePers;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPricePerByIdRequestConsumer : IConsumer<GetPricePerByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPricePerByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPricePerByIdRequest> context)
        {
            Log.Warning($"GetPricePerByIdRequestConsumer: request={context.Message.ToJson()}");

            var pricePers = await _mediator.Send(new GetPricePerQuery() { Id = context.Message.Id });
            if (pricePers?.Data == null) await context.RespondAsync(null);
            var response = new GetPricePerByIdResponse
            {
                Id = pricePers.Data.Id,
                Code = pricePers.Data.Code,
                Name = pricePers.Data.Name,
                IsActive = pricePers.Data.IsActive
            };
            Log.Information($"GetPricePerByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}