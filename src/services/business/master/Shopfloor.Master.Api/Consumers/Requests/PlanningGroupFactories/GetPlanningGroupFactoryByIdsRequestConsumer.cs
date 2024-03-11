using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Dtos;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Api.Consumers.Requests.PlanningGroups
{
    public class GetPlanningGroupFactoryByIdsRequestConsumer : IConsumer<GetPlanningGroupFactoryByIdsRequest>
    {
        #region Initialization

        private readonly IPlanningGroupFactoryRepository _planningGroupFactoryRepository;

        public GetPlanningGroupFactoryByIdsRequestConsumer(
            IPlanningGroupFactoryRepository planningGroupFactoryRepository)
        {
            _planningGroupFactoryRepository = planningGroupFactoryRepository;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPlanningGroupFactoryByIdsRequest> context)
        {
            Log.Warning($"GetPlanningGroupFactoryByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _planningGroupFactoryRepository.GetByIds(context.Message.Ids);
            if (structures.Count == 0) await context.RespondAsync(null);

            var response = new GetPlanningGroupFactoryByIdsResponse();
            if (structures?.Count > 0)
            {
                response.PlanningGroupFactrories = structures.Select(x => new PlanningGroupFactoryDto
                {
                    Id = x.Id,
                    PlanningGroupId = x.PlanningGroupId,
                    FactoryId = x.FactoryId,
                    FactoryName = x?.Factory?.Name,
                    ProcessName = x?.PlanningGroup?.Process?.Name,
                }).ToList();
            }

            Log.Information($"GetPlanningGroupFactoryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
