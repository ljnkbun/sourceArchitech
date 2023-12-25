using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.MaterialTypeMapProductGroups;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMaterialTypeMapProductGroupsRequestConsumer : IConsumer<GetMaterialTypeMapProductGroupsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMaterialTypeMapProductGroupsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMaterialTypeMapProductGroupsRequest> context)
        {
            Log.Warning($"GetMaterialTypeMapProductGroupsRequestConsumer: request={context.Message.ToJson()}");

            var accountGroup = await _mediator.Send(new GetMaterialTypeMapProductGroupsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                MaterialTypeId = context.Message.MaterialTypeId,
                ProductGroupId = context.Message.ProductGroupId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (accountGroup?.Data == null) await context.RespondAsync(null);
            var response = new GetMaterialTypeMapProductGroupsResponse
            {
                Data = accountGroup.Data.Select(x => new GetMaterialTypeMapProductGroupByIdResponse
                {
                    Id = x.Id,
                    MaterialTypeId = x.MaterialTypeId,
                    ProductGroupId = x.ProductGroupId,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetMaterialTypeMapProductGroupsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}