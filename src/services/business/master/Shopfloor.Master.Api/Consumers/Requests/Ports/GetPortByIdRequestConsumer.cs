using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Ports;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPortByIdRequestConsumer : IConsumer<GetPortByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPortByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPortByIdRequest> context)
        {
            Log.Warning($"GetPortByIdRequestConsumer: request={context.Message.ToJson()}");

            var ports = await _mediator.Send(new GetPortQuery() { Id = context.Message.Id });
            if (ports?.Data == null) await context.RespondAsync(null);
            var response = new GetPortByIdResponse
            {
                Id = ports.Data.Id,
                Code = ports.Data.Code,
                Name = ports.Data.Name,
                IsActive = ports.Data.IsActive
            };
            Log.Information($"GetPortByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}