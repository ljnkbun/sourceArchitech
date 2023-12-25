using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Origins;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetOriginByIdRequestConsumer : IConsumer<GetOriginByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetOriginByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetOriginByIdRequest> context)
        {
            Log.Warning($"GetOriginByIdRequestConsumer: request={context.Message.ToJson()}");

            var origins = await _mediator.Send(new GetOriginQuery() { Id = context.Message.Id });
            if (origins?.Data == null) await context.RespondAsync(null);
            var response = new GetOriginByIdResponse
            {
                Id = origins.Data.Id,
                Code = origins.Data.Code,
                Name = origins.Data.Name,
                IsActive = origins.Data.IsActive
            };
            Log.Information($"GetOriginByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}