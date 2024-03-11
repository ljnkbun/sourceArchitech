using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.MaterialRequests.DynamicColumns;
using Shopfloor.EventBus.Models.Responses.MaterialRequests.DynamicColumns;
using Shopfloor.Material.Application.Query.DynamicColumns;

namespace Shopfloor.Material.Api.Consumers.Requests.DynamicColumns
{
    public class GetDynamicColumnByIdRequestConsumer : IConsumer<GetDynamicColumnByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDynamicColumnByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDynamicColumnByIdRequest> context)
        {
            Log.Warning($"GetGetDynamicColumnByIdRequestConsumer: request={context.Message.ToJson()}");

            var DynamicColumnRes = await _mediator.Send(new GetDynamicColumnQuery() { Id = context.Message.Id });
            if (DynamicColumnRes?.Data == null) await context.RespondAsync(null);
            var response = new GetDynamicColumnByIdResponse
            {
                Id = DynamicColumnRes.Data.Id,
                Code = DynamicColumnRes.Data.Code,
                Name = DynamicColumnRes.Data.Name,
                IsActive = DynamicColumnRes.Data.IsActive
            };
            Log.Information($"GetGetDynamicColumnByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}