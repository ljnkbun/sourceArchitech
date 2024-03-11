using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.Master.Application.Query.Lines;

namespace Shopfloor.Master.Api.Consumers.Requests.Lines
{
    public class GetLineByIdRequestConsumer : IConsumer<GetLineByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetLineByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetLineByIdRequest> context)
        {
            Log.Warning($"GetLineByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetLineQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetLineByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                Worker = structures.Data.Worker,
                WFXLineId = structures.Data.WFXLineId,
                FactoryId = structures.Data.FactoryId,
                ProcessId = structures.Data.ProcessId,
                IsActive = structures.Data.IsActive,
            };
            Log.Information($"GetLineByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
