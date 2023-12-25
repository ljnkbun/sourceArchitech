using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CategoryMapMaterialTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCategoryMapMaterialTypesRequestConsumer : IConsumer<GetCategoryMapMaterialTypesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCategoryMapMaterialTypesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCategoryMapMaterialTypesRequest> context)
        {
            Log.Warning($"GetCategoryMapMaterialTypesRequestConsumer: request={context.Message.ToJson()}");

            var accountGroup = await _mediator.Send(new GetCategoryMapMaterialTypesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                MaterialTypeId = context.Message.MaterialTypeId,
                CategoryId = context.Message.CategoryId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (accountGroup?.Data == null) await context.RespondAsync(null);
            var response = new GetCategoryMapMaterialTypesResponse
            {
                Data = accountGroup.Data.Select(x => new GetCategoryMapMaterialTypeByIdResponse
                {
                    Id = x.Id,
                    MaterialTypeId = x.MaterialTypeId,
                    CategoryId = x.CategoryId,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCategoryMapMaterialTypesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}