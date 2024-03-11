using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories;
using Shopfloor.Master.Application.Query.PlanningGroupFactories;

namespace Shopfloor.Master.Api.Consumers.Requests.PlanningGroups
{
    public class GetPlanningGroupFactoryByIdRequestConsumer : IConsumer<GetPlanningGroupFactoryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPlanningGroupFactoryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPlanningGroupFactoryByIdRequest> context)
        {
            Log.Warning($"GetPlanningGroupFactoryByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetPlanningGroupFactoryQuery() { Id = context.Message.Id });
            if (structures.Data == null) await context.RespondAsync(null);

            var response = new GetPlanningGroupFactoryByIdResponse
            {
                Id = structures.Data.Id,
                PlanningGroupId = structures.Data.PlanningGroupId,
                FactoryId = structures.Data.FactoryId,
                FactoryName = structures.Data?.Factory?.Name,
                ProcessName = structures.Data?.PlanningGroup?.Process?.Name,
            };

            Log.Information($"GetPlanningGroupFactoryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
