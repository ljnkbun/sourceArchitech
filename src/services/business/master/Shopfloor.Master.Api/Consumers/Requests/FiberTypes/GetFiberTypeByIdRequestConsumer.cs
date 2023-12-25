using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.FiberTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFiberTypeByIdRequestConsumer : IConsumer<GetFiberTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFiberTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFiberTypeByIdRequest> context)
        {
            Log.Warning($"GetFiberTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var fiberTypes = await _mediator.Send(new GetFiberTypeQuery() { Id = context.Message.Id });
            if (fiberTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetFiberTypeByIdResponse
            {
                Id = fiberTypes.Data.Id,
                Code = fiberTypes.Data.Code,
                Name = fiberTypes.Data.Name,
                IsActive = fiberTypes.Data.IsActive
            };
            Log.Information($"GetFiberTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}