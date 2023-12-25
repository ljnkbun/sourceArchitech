using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Countries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCountriesRequestConsumer : IConsumer<GetCountriesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCountriesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCountriesRequest> context)
        {
            Log.Warning($"GetCountriesRequestConsumer: request={context.Message.ToJson()}");

            var countries = await _mediator.Send(new GetCountriesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (countries?.Data == null) await context.RespondAsync(null);
            var response = new GetCountriesResponse
            {
                Data = countries.Data.Select(x => new GetCountryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCountriesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}