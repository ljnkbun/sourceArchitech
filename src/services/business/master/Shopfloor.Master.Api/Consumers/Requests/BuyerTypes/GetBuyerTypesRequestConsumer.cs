using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.BuyerTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetBuyerTypesRequestConsumer : IConsumer<GetBuyerTypesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetBuyerTypesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetBuyerTypesRequest> context)
        {
            Log.Warning($"GetBuyerTypesRequestConsumer: request={context.Message.ToJson()}");

            var buyerTypes = await _mediator.Send(new GetBuyerTypesQuery()
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
            if (buyerTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetBuyerTypesResponse
            {
                Data = buyerTypes.Data.Select(x => new GetBuyerTypeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetBuyerTypesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}