using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Strengths;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetStrengthByIdRequestConsumer : IConsumer<GetStrengthByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetStrengthByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetStrengthByIdRequest> context)
        {
            Log.Warning($"GetStrengthByIdRequestConsumer: request={context.Message.ToJson()}");

            var strengths = await _mediator.Send(new GetStrengthQuery() { Id = context.Message.Id });
            if (strengths?.Data == null) await context.RespondAsync(null);
            var response = new GetStrengthByIdResponse
            {
                Id = strengths.Data.Id,
                Code = strengths.Data.Code,
                Name = strengths.Data.Name,
                IsActive = strengths.Data.IsActive
            };
            Log.Information($"GetStrengthByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}