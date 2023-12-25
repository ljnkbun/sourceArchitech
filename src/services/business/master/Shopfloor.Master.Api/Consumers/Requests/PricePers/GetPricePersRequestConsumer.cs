using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.PricePers;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPricePersRequestConsumer : IConsumer<GetPricePersRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPricePersRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPricePersRequest> context)
        {
            Log.Warning($"GetPricePersRequestConsumer: request={context.Message.ToJson()}");

            var pricePers = await _mediator.Send(new GetPricePersQuery()
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
            if (pricePers?.Data == null) await context.RespondAsync(null);
            var response = new GetPricePersResponse
            {
                Data = pricePers.Data.Select(x => new GetPricePerByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetPricePersRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}