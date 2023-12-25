using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SubCategories;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSubCategoriesRequestConsumer : IConsumer<GetSubCategoriesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSubCategoriesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSubCategoriesRequest> context)
        {
            Log.Warning($"GetSubCategoriesRequestConsumer: request={context.Message.ToJson()}");

            var subCategories = await _mediator.Send(new GetSubCategoriesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                ExciseTarrifNo = context.Message.ExciseTarrifNo,
                PackagingUnit = context.Message.PackagingUnit,
                ByPassPriceList = context.Message.ByPassPriceList,
                DefaultInactiveIndent = context.Message.DefaultInactiveIndent,
                ProductGroupId = context.Message.ProductGroupId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (subCategories?.Data == null) await context.RespondAsync(null);
            var response = new GetSubCategoriesResponse
            {
                Data = subCategories.Data.Select(x => new GetSubCategoryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSubCategoriesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}