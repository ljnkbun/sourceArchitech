using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Patterns;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPatternByIdRequestConsumer : IConsumer<GetPatternByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPatternByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPatternByIdRequest> context)
        {
            Log.Warning($"GetPatternByIdRequestConsumer: request={context.Message.ToJson()}");

            var patterns = await _mediator.Send(new GetPatternQuery() { Id = context.Message.Id });
            if (patterns?.Data == null) await context.RespondAsync(null);
            var response = new GetPatternByIdResponse
            {
                Id = patterns.Data.Id,
                Code = patterns.Data.Code,
                Name = patterns.Data.Name,
                IsActive = patterns.Data.IsActive
            };
            Log.Information($"GetPatternByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}