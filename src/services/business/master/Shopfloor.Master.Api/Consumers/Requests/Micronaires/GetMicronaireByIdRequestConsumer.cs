using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Micronaires;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMicronaireByIdRequestConsumer : IConsumer<GetMicronaireByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMicronaireByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMicronaireByIdRequest> context)
        {
            Log.Warning($"GetMicronaireByIdRequestConsumer: request={context.Message.ToJson()}");

            var micronaires = await _mediator.Send(new GetMicronaireQuery() { Id = context.Message.Id });
            if (micronaires?.Data == null) await context.RespondAsync(null);
            var response = new GetMicronaireByIdResponse
            {
                Id = micronaires.Data.Id,
                Code = micronaires.Data.Code,
                Name = micronaires.Data.Name,
                IsActive = micronaires.Data.IsActive
            };
            Log.Information($"GetMicronaireByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}