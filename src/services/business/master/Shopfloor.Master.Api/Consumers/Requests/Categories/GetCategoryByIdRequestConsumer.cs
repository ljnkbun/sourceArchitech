using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Categories;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCategoryByIdRequestConsumer : IConsumer<GetCategoryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCategoryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCategoryByIdRequest> context)
        {
            Log.Warning($"GetGetCategoryByIdRequestConsumer: request={context.Message.ToJson()}");

            var categoryRes = await _mediator.Send(new GetCategoryQuery() { Id = context.Message.Id });
            if (categoryRes?.Data == null) await context.RespondAsync(null);
            var response = new GetCategoryByIdResponse
            {
                Id = categoryRes.Data.Id,
                Code = categoryRes.Data.Code,
                Name = categoryRes.Data.Name,
                IsActive = categoryRes.Data.IsActive
            };
            Log.Information($"GetGetCategoryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}