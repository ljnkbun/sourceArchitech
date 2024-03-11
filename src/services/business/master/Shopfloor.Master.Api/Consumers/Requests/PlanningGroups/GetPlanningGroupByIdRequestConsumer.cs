using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups;
using Shopfloor.Master.Application.Query.PlanningGroups;

namespace Shopfloor.Master.Api.Consumers.Requests.PlanningGroups
{
    public class GetPlanningGroupByIdRequestConsumer : IConsumer<GetPlanningGroupByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPlanningGroupByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPlanningGroupByIdRequest> context)
        {
            Log.Warning($"GetPlanningGroupByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetPlanningGroupQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetPlanningGroupByIdResponse
            {
                Id = structures.Data.Id,
                ProcessId = structures.Data.ProcessId,
                CalendarId = structures.Data.CalendarId,

                PlanningGroupFactories = structures.Data.PlanningGroupFactories?.Select(x => new PlanningGroupFactory()
                {
                    Id = x.Id,
                    FactoryId = x.FactoryId,
                }).ToList()
            };
            Log.Information($"GetPlanningGroupByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
