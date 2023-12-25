using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Gauges;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGaugeByIdRequestConsumer : IConsumer<GetGaugeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGaugeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGaugeByIdRequest> context)
        {
            Log.Warning($"GetGaugeByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetGaugeQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetGaugeByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                IsActive = structures.Data.IsActive
            };
            Log.Information($"GetGaugeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}