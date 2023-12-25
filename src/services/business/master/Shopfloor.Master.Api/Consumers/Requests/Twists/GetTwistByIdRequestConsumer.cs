using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Twists;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetTwistByIdRequestConsumer : IConsumer<GetTwistByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetTwistByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetTwistByIdRequest> context)
        {
            Log.Warning($"GetTwistByIdRequestConsumer: request={context.Message.ToJson()}");

            var twists = await _mediator.Send(new GetTwistQuery() { Id = context.Message.Id });
            if (twists?.Data == null) await context.RespondAsync(null);
            var response = new GetTwistByIdResponse
            {
                Id = twists.Data.Id,
                Code = twists.Data.Code,
                Name = twists.Data.Name,
                IsActive = twists.Data.IsActive
            };
            Log.Information($"GetTwistByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}