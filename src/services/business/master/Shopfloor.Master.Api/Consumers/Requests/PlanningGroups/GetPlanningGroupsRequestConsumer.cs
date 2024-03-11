using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups;
using Shopfloor.Master.Application.Query.PlanningGroups;

namespace Shopfloor.Master.Api.Consumers.Requests.PlanningGroups
{
    public class GetPlanningGroupsRequestConsumer : IConsumer<GetPlanningGroupsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPlanningGroupsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPlanningGroupsRequest> context)
        {
            Log.Warning($"GetPlanningGroupsRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetPlanningGroupsQuery()
            {
                ProcessId = context.Message.ProcessId,
                CalendarId = context.Message.CalendarId,
            });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetPlanningGroupsResponse
            {
                Data = structures.Data.Select(x => new GetPlanningGroupByIdResponse
                {
                    Id = x.Id,
                    ProcessId = x.ProcessId,
                    CalendarId = x.CalendarId,
                    PlanningGroupFactories = x.PlanningGroupFactories.Select(x => new PlanningGroupFactory()
                    {
                        Id = x.Id,
                        FactoryId = x.FactoryId,
                    }).ToList(),
                }).ToList()
            };
            Log.Information($"GetPlanningGroupsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
