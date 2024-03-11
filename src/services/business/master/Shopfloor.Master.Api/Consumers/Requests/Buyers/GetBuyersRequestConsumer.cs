using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Buyers;
using Shopfloor.EventBus.Models.Responses.Masters.Buyers;
using Shopfloor.Master.Application.Query.Buyers;

namespace Shopfloor.Master.Api.Consumers.Requests.Buyers
{
    public class GetBuyersRequestConsumer : IConsumer<GetBuyersRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetBuyersRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetBuyersRequest> context)
        {
            Log.Warning($"GetBuyersRequestConsumer: request={context.Message.ToJson()}");

            var buyers = await _mediator.Send(new GetBuyersQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                WFXBuyerId = context.Message.WFXBuyerId,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (buyers?.Data == null) await context.RespondAsync(null);
            var response = new GetBuyersResponse
            {
                Data = buyers.Data.Select(x => new GetBuyerByIdResponse
                {
                    Id = x.Id,
                    WFXBuyerId = x.WFXBuyerId,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetBuyersRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}