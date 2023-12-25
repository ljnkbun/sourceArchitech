using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Currencies;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCurrencyByIdRequestConsumer : IConsumer<GetCurrencyByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCurrencyByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCurrencyByIdRequest> context)
        {
            Log.Warning($"GetCurrencyByIdRequestConsumer: request={context.Message.ToJson()}");

            var currencies = await _mediator.Send(new GetCurrencyQuery() { Id = context.Message.Id });
            if (currencies?.Data == null) await context.RespondAsync(null);
            var response = new GetCurrencyByIdResponse
            {
                Id = currencies.Data.Id,
                Code = currencies.Data.Code,
                Name = currencies.Data.Name,
                IsActive = currencies.Data.IsActive
            };
            Log.Information($"GetCurrencyByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}