using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ColorDefinitions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetColorDefinitionByIdRequestConsumer : IConsumer<GetColorDefinitionByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetColorDefinitionByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetColorDefinitionByIdRequest> context)
        {
            Log.Warning($"GetColorDefinitionByIdRequestConsumer: request={context.Message.ToJson()}");

            var colorDefinition = await _mediator.Send(new GetColorDefinitionQuery() { Id = context.Message.Id });
            if (colorDefinition?.Data == null) await context.RespondAsync(null);
            var response = new GetColorDefinitionByIdResponse
            {
                Id = colorDefinition.Data.Id,
                Code = colorDefinition.Data.Code,
                Name = colorDefinition.Data.Name,
                IsActive = colorDefinition.Data.IsActive
            };
            Log.Information($"GetColorDefinitionByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}