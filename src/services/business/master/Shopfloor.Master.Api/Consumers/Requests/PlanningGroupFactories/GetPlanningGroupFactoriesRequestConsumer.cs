using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories;
using Shopfloor.Master.Application.Query.PlanningGroupFactories;

namespace Shopfloor.Master.Api.Consumers.Requests.PlanningGroups
{
    public class GetPlanningGroupFactoriesRequestConsumer : IConsumer<GetPlanningGroupFactoriesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPlanningGroupFactoriesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPlanningGroupFactoriesRequest> context)
        {
            Log.Warning($"GetPlanningGroupFactoriesRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetPlanningGroupFactoriesQuery()
            {
                PlanningGroupId = context.Message.PlanningGroupId,
                FactoryId = context.Message.FactoryId,
            });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetPlanningGroupFactoriesResponse
            {
                Data = structures.Data.Select(x => new GetPlanningGroupFactoryByIdResponse
                {
                    Id = x.Id,
                    PlanningGroupId = x.PlanningGroupId,
                    FactoryId = x.FactoryId,
                }).ToList()
            };
            Log.Information($"GetPlanningGroupFactoriesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
