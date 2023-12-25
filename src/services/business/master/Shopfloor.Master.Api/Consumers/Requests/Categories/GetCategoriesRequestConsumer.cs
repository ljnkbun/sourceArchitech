using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Categories;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCategoriesRequestConsumer : IConsumer<GetCategoriesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCategoriesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCategoriesRequest> context)
        {
            Log.Warning($"GetCategoriesRequestConsumer: request={context.Message.ToJson()}");

            var categoriesRes = await _mediator.Send(new GetCategoriesQuery()
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
            if (categoriesRes?.Data == null) await context.RespondAsync(null);
            var response = new GetCategoriesResponse
            {
                Data = categoriesRes.Data.Select(x => new GetCategoryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCategoriesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}