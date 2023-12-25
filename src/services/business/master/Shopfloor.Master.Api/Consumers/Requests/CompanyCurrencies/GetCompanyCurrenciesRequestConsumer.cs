using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CompanyCurrencies;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCompanyCurrenciesRequestConsumer : IConsumer<GetCompanyCurrenciesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCompanyCurrenciesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCompanyCurrenciesRequest> context)
        {
            Log.Warning($"GetCompanyCurrenciesRequestConsumer: request={context.Message.ToJson()}");

            var companyCurrencies = await _mediator.Send(new GetCompanyCurrenciesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                RateExchange = context.Message.RateExchange,
                Symbol = context.Message.Symbol,
                ValidFrom = context.Message.ValidFrom,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (companyCurrencies?.Data == null) await context.RespondAsync(null);
            var response = new GetCompanyCurrenciesResponse
            {
                Data = companyCurrencies.Data.Select(x => new GetCompanyCurrencyByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    RateExchange = x.RateExchange,
                    Symbol = x.Symbol,
                    ValidFrom = x.ValidFrom,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCompanyCurrenciesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}