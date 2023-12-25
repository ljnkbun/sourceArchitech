using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Processes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProcessByIdRequestConsumer : IConsumer<GetProcessByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProcessByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProcessByIdRequest> context)
        {
            Log.Warning($"GetProcessByIdRequestConsumer: request={context.Message.ToJson()}");

            var spinningProcesss = await _mediator.Send(new GetProcessQuery() { Id = context.Message.Id });
            if (spinningProcesss?.Data == null) await context.RespondAsync(null);
            var response = new GetProcessByIdResponse
            {
                Id = spinningProcesss.Data.Id,
                Code = spinningProcesss.Data.Code,
                Name = spinningProcesss.Data.Name,
                IsActive = spinningProcesss.Data.IsActive
            };
            Log.Information($"GetProcessByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}