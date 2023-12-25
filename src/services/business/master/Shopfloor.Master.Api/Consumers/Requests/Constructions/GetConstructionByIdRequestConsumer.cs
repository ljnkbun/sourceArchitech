using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Constructions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetConstructionByIdRequestConsumer : IConsumer<GetConstructionByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetConstructionByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetConstructionByIdRequest> context)
        {
            Log.Warning($"GetConstructionByIdRequestConsumer: request={context.Message.ToJson()}");

            var constructions = await _mediator.Send(new GetConstructionQuery() { Id = context.Message.Id });
            if (constructions?.Data == null) await context.RespondAsync(null);
            var response = new GetConstructionByIdResponse
            {
                Id = constructions.Data.Id,
                Code = constructions.Data.Code,
                Name = constructions.Data.Name,
                IsActive = constructions.Data.IsActive
            };
            Log.Information($"GetConstructionByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}