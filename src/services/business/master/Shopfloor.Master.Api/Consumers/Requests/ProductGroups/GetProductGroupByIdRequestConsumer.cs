using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ProductGroups;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProductGroupByIdRequestConsumer : IConsumer<GetProductGroupByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProductGroupByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProductGroupByIdRequest> context)
        {
            Log.Warning($"GetProductGroupByIdRequestConsumer: request={context.Message.ToJson()}");

            var productGroups = await _mediator.Send(new GetProductGroupQuery() { Id = context.Message.Id });
            if (productGroups?.Data == null) await context.RespondAsync(null);
            var response = new GetProductGroupByIdResponse
            {
                Id = productGroups.Data.Id,
                Code = productGroups.Data.Code,
                Name = productGroups.Data.Name,
                CategoryId = productGroups.Data.CategoryId,
                IsActive = productGroups.Data.IsActive
            };
            Log.Information($"GetProductGroupByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}