using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ProductGroups;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProductGroupsRequestConsumer : IConsumer<GetProductGroupsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProductGroupsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProductGroupsRequest> context)
        {
            Log.Warning($"GetProductGroupsRequestConsumer: request={context.Message.ToJson()}");

            var productGroups = await _mediator.Send(new GetProductGroupsQuery()
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
            if (productGroups?.Data == null) await context.RespondAsync(null);
            var response = new GetProductGroupsResponse
            {
                Data = productGroups.Data.Select(x => new GetProductGroupByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetProductGroupsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}