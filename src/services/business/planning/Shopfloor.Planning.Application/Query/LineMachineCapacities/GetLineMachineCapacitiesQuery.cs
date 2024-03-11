using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Application.Models.LineMachineCapacities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.LineMachineCapacities
{
    public class GetLineMachineCapacitiesQuery : IRequest<PagedResponse<IReadOnlyList<LineMachineCapcityCustomModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PlanningGroupId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetLineMachineCapacitiesQueryHandler : IRequestHandler<GetLineMachineCapacitiesQuery, PagedResponse<IReadOnlyList<LineMachineCapcityCustomModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILineMachineCapacityRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public GetLineMachineCapacitiesQueryHandler(IMapper mapper,
            ILineMachineCapacityRepository repository,
            IRequestClientService requestClientService)
        {
            _mapper = mapper;
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<PagedResponse<IReadOnlyList<LineMachineCapcityCustomModel>>> Handle(GetLineMachineCapacitiesQuery request, CancellationToken cancellationToken)
        {
            #region ValidData

            var planningGroup =
                await _requestClientService.GetResponseAsync<GetPlanningGroupByIdRequest, GetPlanningGroupByIdResponse>(
                    new() { Id = request.PlanningGroupId }, cancellationToken);

            #endregion

            #region Globals

            // Lines/Machines form master
            var factoryIds = planningGroup.Message?.PlanningGroupFactories?.Select(x => x.FactoryId).ToList();

            var linesResponse = await _requestClientService.GetResponseAsync<GetLinesRequest, GetLinesResponse>(new(), cancellationToken);
            var lineIds = linesResponse?.Message?.Data.Where(x => x.ProcessId == planningGroup?.Message?.ProcessId && factoryIds.Contains(x.FactoryId.Value)).Select(x => x.Id).ToList();

            var machinesResponse = await _requestClientService.GetResponseAsync<GetMachinesRequest, GetMachinesResponse>(new(), cancellationToken);
            var machineIds = machinesResponse?.Message?.Data.Where(x => x.ProcessId == planningGroup?.Message?.ProcessId && factoryIds.Contains(x.FactoryId.Value)).Select(x => x.Id).ToList();

            #endregion

            var factoryCapacityModels = await _repository.GetLineMachineCapacityByDate(request.FromDate, request.ToDate, lineIds, machineIds);
            var mapModels = _mapper.Map<List<LineMachineCapacityModel>>(factoryCapacityModels);

            var groupCustomModels = mapModels?
                .GroupBy(fcModel => new { fcModel.MachineId, fcModel.MachineName, fcModel.LineId, fcModel.LineName })
                .Select(group => new LineMachineCapcityCustomModel
                {
                    MachineId = group.Key.MachineId ?? 0,
                    MachineName = group.Key.MachineName,
                    Gauge = machinesResponse?.Message?.Data?.FirstOrDefault(x => x.Id == group.Key.MachineId)?.Gauge,
                    MachineDiameter = machinesResponse?.Message?.Data?.FirstOrDefault(x => x.Id == group.Key.MachineId)?.MachineDiameter,
                    LineId = group.First().LineId ?? 0,
                    LineName = group.Key.LineName,
                    LineMachineCapacities = group.Select(fcModel => new LineMachineCapacityDetail
                    {
                        Date = fcModel.Date,
                        Standingcapacity = fcModel.Standingcapacity,
                        WorkingHours = fcModel.WorkingHours,
                        Week = fcModel.Week,
                        Month = fcModel.Month
                    }).ToList()
                }).ToList();

            return new PagedResponse<IReadOnlyList<LineMachineCapcityCustomModel>>(groupCustomModels, request.PageNumber, request.PageSize);
        }
    }
}
