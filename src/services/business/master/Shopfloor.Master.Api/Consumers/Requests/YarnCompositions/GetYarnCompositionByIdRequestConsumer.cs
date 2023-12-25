using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.YarnCompositions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetYarnCompositionByIdRequestConsumer : IConsumer<GetYarnCompositionByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetYarnCompositionByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetYarnCompositionByIdRequest> context)
        {
            Log.Warning($"GetYarnCompositionByIdRequestConsumer: request={context.Message.ToJson()}");

            var yarnCompositions = await _mediator.Send(new GetYarnCompositionQuery() { Id = context.Message.Id });
            if (yarnCompositions?.Data == null) await context.RespondAsync(null);
            var response = new GetYarnCompositionByIdResponse
            {
                Id = yarnCompositions.Data.Id,
                Code = yarnCompositions.Data.Code,
                Name = yarnCompositions.Data.Name,
                IsActive = yarnCompositions.Data.IsActive
            };
            Log.Information($"GetYarnCompositionByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}