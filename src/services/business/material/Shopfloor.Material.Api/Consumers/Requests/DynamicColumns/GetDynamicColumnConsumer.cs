using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.MaterialRequests.DynamicColumns;
using Shopfloor.EventBus.Models.Responses.MaterialRequests.DynamicColumns;
using Shopfloor.Material.Application.Query.DynamicColumns;

namespace Shopfloor.Material.Api.Consumers.Requests.DynamicColumns
{
    public class GetDynamicColumnsRequestConsumer : IConsumer<GetDynamicColumnsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDynamicColumnsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDynamicColumnsRequest> context)
        {
            Log.Warning($"GetDynamicColumnsRequestConsumer: request={context.Message.ToJson()}");

            var dynamicColumnsRes = await _mediator.Send(new GetDynamicColumnsQuery()
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
            if (dynamicColumnsRes?.Data == null) await context.RespondAsync(null);
            var response = new GetDynamicColumnsResponse
            {
                Data = dynamicColumnsRes.Data.Select(x => new GetDynamicColumnByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetDynamicColumnsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}