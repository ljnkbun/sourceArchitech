using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CompanyCurrencies;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCompanyCurrencyByIdRequestConsumer : IConsumer<GetCompanyCurrencyByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCompanyCurrencyByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCompanyCurrencyByIdRequest> context)
        {
            Log.Warning($"GetCompanyCurrencyByIdRequestConsumer: request={context.Message.ToJson()}");

            var CompanyCurrencies = await _mediator.Send(new GetCompanyCurrencyQuery() { Id = context.Message.Id });
            if (CompanyCurrencies?.Data == null) await context.RespondAsync(null);
            var response = new GetCompanyCurrencyByIdResponse
            {
                Id = CompanyCurrencies.Data.Id,
                Code = CompanyCurrencies.Data.Code,
                Name = CompanyCurrencies.Data.Name,
                RateExchange = CompanyCurrencies.Data.RateExchange,
                Symbol = CompanyCurrencies.Data.Symbol,
                ValidFrom = CompanyCurrencies.Data.ValidFrom,
                IsActive = CompanyCurrencies.Data.IsActive
            };
            Log.Information($"GetCompanyCurrencyByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}