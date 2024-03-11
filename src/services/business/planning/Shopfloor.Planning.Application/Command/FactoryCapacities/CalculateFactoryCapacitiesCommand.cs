using MediatR;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Dtos;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Application.Models.FactoryCapacities;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.FactoryCapacities
{
    public class CalculateFactoryCapacitiesCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class CalculateFactoryCapacitiesHandler : IRequestHandler<CalculateFactoryCapacitiesCommand, Core.Models.Responses.Response<bool>>
    {
        private readonly ICapacityColorRepository _capacityColorRepository;
        private readonly IFactoryCapacityRepository _factoryCapacityRepository;
        private readonly IStripSchedulePlanningDetailRepository _stripSchedulePlanningDetailRepository;
        private readonly IStripFactoryRepository _stripFactoryRepository;
        private readonly IRequestClientService _requestClientService;

        public CalculateFactoryCapacitiesHandler(
            ICapacityColorRepository capacityColorRepository,
            IFactoryCapacityRepository factoryCapacityRepository,
            IStripSchedulePlanningDetailRepository stripSchedulePlanningDetailRepository,
            IRequestClientService requestClientService,
            IStripFactoryRepository stripFactoryRepository)
        {
            _capacityColorRepository = capacityColorRepository;
            _factoryCapacityRepository = factoryCapacityRepository;
            _stripSchedulePlanningDetailRepository = stripSchedulePlanningDetailRepository;
            _requestClientService = requestClientService;
            _stripFactoryRepository = stripFactoryRepository;

        }

        public async Task<Core.Models.Responses.Response<bool>> Handle(CalculateFactoryCapacitiesCommand request, CancellationToken cancellationToken)
        {
            #region ValidData

            var planningGroups = await _requestClientService
                .GetResponseAsync<GetPlanningGroupsRequest, GetPlanningGroupsResponse>(new() { CalendarId = null, ProcessId = null }, cancellationToken);

            // Check if factory processes exist
            if (planningGroups?.Message?.Data?.Count == 0)
                return new($"PlanningGroupsRes not found");

            #endregion

            #region Globals

            // Lines/Machine/PlanningGroupFactory/Calendar form master
            var linesResponse = await _requestClientService.GetResponseAsync<GetLinesRequest, GetLinesResponse>(new(), cancellationToken);
            var machinesResponse = await _requestClientService.GetResponseAsync<GetMachinesRequest, GetMachinesResponse>(new(), cancellationToken);
            var planningGrooupFactoryIds = planningGroups.Message.Data?.SelectMany(pg => pg.PlanningGroupFactories).Select(pf => pf.Id).ToList();
            var planningGrooupFactories = await _requestClientService.GetResponseAsync<GetPlanningGroupFactoryByIdsRequest, GetPlanningGroupFactoryByIdsResponse>(new() { Ids = planningGrooupFactoryIds }, cancellationToken);
            var calendarIds = planningGroups.Message.Data.Select(x => x.CalendarId).ToList();
            var calendarResponse = await _requestClientService.GetResponseAsync<GetCalendarByIdsRequest, GetCalendarByIdsResponse>(new() { Ids = calendarIds }, cancellationToken);
            var holidayResponse = await _requestClientService.GetResponseAsync<GetHolidaysRequest, GetHolidaysResponse>(new(), cancellationToken);

            // Data from factoryCapacities
            var factoryCapacities = await _factoryCapacityRepository.GetFactoryCapacityByDate(request.FromDate, request.ToDate);

            // Additional data
            var colorStripSchedulePlanningDetail = new ColorStripSchedulePlanningDetail
            {
                CapacityColors = await _capacityColorRepository.GetAllAsync(),
                StripSchedulePlanningDetails = await _stripSchedulePlanningDetailRepository.GetAllAsync(),
            };

            // StripFactories data
            var plGroupFactoryIds = planningGroups.Message.Data.SelectMany(x => x.PlanningGroupFactories).Select(y => y.Id).ToList();
            var stripFactories = await _stripFactoryRepository.GetStripFactoryByPlanningFactoryIds(plGroupFactoryIds, request.FromDate, request.ToDate);

            #endregion

            #region Logic

            var lstFactoryCapacity = new List<FactoryCapacity>();
            // Process each factory
            foreach (var planningGroup in planningGroups?.Message?.Data)
            {
                var lines = linesResponse?.Message?.Data
                    .Where(x => x.ProcessId == planningGroup.ProcessId);
                var machines = machinesResponse?.Message?.Data
                    .Where(x => x.ProcessId == planningGroup.ProcessId);

                var calendar = calendarResponse?.Message?.Calendars?.FirstOrDefault(x => x.Id == planningGroup.CalendarId);
                foreach (var pgf in planningGroup.PlanningGroupFactories)
                {
                    var factoryIdGetLines = lines.Where(x => x.FactoryId == pgf.FactoryId);
                    var factoryIdGetMachines = machines.Where(x => x.FactoryId == pgf.FactoryId);

                    // Get lines or machines
                    var mapLineOrMachines = GetFilterLinesOrMachines(factoryIdGetLines.ToList(), factoryIdGetMachines.ToList());

                    // Calculate factory capacities
                    var tempCapacities = CalculateFactoryCapacities(calendar, mapLineOrMachines, request.FromDate, request.ToDate);
                    var planningGroupFactory = planningGrooupFactories?.Message?.PlanningGroupFactrories?.FirstOrDefault(x => x.Id == pgf.Id);

                    // Update factory capacities for each date
                    for (DateTime date = request.FromDate; date <= request.ToDate; date = date.AddDays(1))
                    {
                        var factoryCapacityObject = factoryCapacities.FirstOrDefault(x => x.Date.Value.Date == date.Date
                            && x.FactoryId == pgf.FactoryId && x.ProcessId == planningGroup.ProcessId);

                        // Get capacity
                        decimal standingCapacity = tempCapacities.Where(x => x.Day == date.Date).Sum(x => x.StandingCapacity.Value);
                        factoryCapacityObject = factoryCapacityObject == null
                            ? CreateFactoryCapacity(date, planningGroupFactory, standingCapacity, colorStripSchedulePlanningDetail, planningGroup.ProcessId)
                            : UpdateFactoryCapacity(date, factoryCapacityObject, standingCapacity, colorStripSchedulePlanningDetail);

                        // Set ActualCapacity when IsPlanning is false
                        var stripFactpryByDate = stripFactories.Where(x => x.PlanningGroupFactoryId == pgf.Id
                            && x.StartDate.Value.Date >= date.Date && x.EndDate.Value.Date <= date.Date).ToList();
                        if (stripFactpryByDate.Count > 0)
                            factoryCapacityObject.ActualCapacity = stripFactpryByDate.Sum(x => x.RemainningQuantity);

                        // Check ActualCapacity in holiday
                        var holiday = holidayResponse?.Message?.Data?.FirstOrDefault(x => x.Date != null && x.Date.Value.Date == date.Date);
                        factoryCapacityObject.ActualCapacity = holiday == null ? factoryCapacityObject.ActualCapacity : 0;

                        lstFactoryCapacity.Add(factoryCapacityObject);
                    }
                }
            }

            #endregion

            #region SaveChanges

            // Save data for FactoryCapacity
            var result = await _factoryCapacityRepository.SaveFactoryCapacitySync(lstFactoryCapacity);
            return new(result);

            #endregion
        }

        /// <summary>
        /// Calculate factoryCapacities
        /// </summary>
        /// <param name="calendarConfigs"></param>
        /// <param name="lineOrMachineResponse"></param>
        /// <param name="factoryId"></param>
        /// <param name="fDate"></param>
        /// <param name="tDate"></param>
        /// <returns></returns>
        public static List<FactoryCapacityTermStadingCapacity> CalculateFactoryCapacities(GetCalendarByIdResponse calendar,
            List<LineOrMachineMapModel> lineOrMachineResponse, DateTime? fDate, DateTime? tDate)
        {
            var factoryCapacities = new List<FactoryCapacityTermStadingCapacity>();

            foreach (var item in lineOrMachineResponse)
            {
                DateTime currentDate = fDate.GetValueOrDefault();
                while (currentDate <= tDate)
                {
                    var timeOnly = GetTimeOnlyForDay(calendar, currentDate);

                    decimal standingCapacity = CalculateStandingCapacity(item, timeOnly);
                    factoryCapacities.Add(new FactoryCapacityTermStadingCapacity
                    {
                        Day = currentDate.Date,
                        DayOfWeek = currentDate.DayOfWeek.ToString(),
                        StandingCapacity = standingCapacity
                    });

                    currentDate = currentDate.AddDays(1);
                }
            }

            return factoryCapacities;
        }

        /// <summary>
        /// Get TimOnly
        /// </summary>
        /// <param name="cld"></param>
        /// <param name="cldDefault"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        private static decimal? GetTimeOnlyForDay(GetCalendarByIdResponse calendar, DateTime currentDate)
        {
            var dayOfWeek = currentDate.DayOfWeek;
            var dayDetail = calendar.CalendarDetails.FirstOrDefault(x => x.DayOfWeek == dayOfWeek);
            return dayDetail?.WorkingHours ?? 0;
        }

        /// <summary>
        /// Calculate capacity standing
        /// </summary>
        /// <param name="item"></param>
        /// <param name="timeOnly"></param>
        /// <returns></returns>
        private static decimal CalculateStandingCapacity(LineOrMachineMapModel item, decimal? timeOnly)
        {
            return item.LineId != null
                ? CalculateCapacityForLine(item.Worker, timeOnly.Value)
                : CalculateCapacityForMachine(item.CapacityMachine, timeOnly.Value);
        }

        /// <summary>
        /// Get list line or machine
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="machines"></param>
        /// <returns></returns>
        private static List<LineOrMachineMapModel> GetFilterLinesOrMachines(List<GetLineByIdResponse> lines, List<GetMachineByIdResponse> machines)
        {
            var filteredLinesOrMachines = new List<LineOrMachineMapModel>();

            if (lines.Count > 0)
            {
                filteredLinesOrMachines = lines
                .Select(x => new LineOrMachineMapModel()
                {
                    LineId = x.Id,
                    Worker = x.Worker
                }).ToList();
                return filteredLinesOrMachines;
            }

            if (machines.Count > 0)
            {
                filteredLinesOrMachines = machines
                    .Select(x => new LineOrMachineMapModel()
                    {
                        MachineId = x.Id,
                        CapacityMachine = x.Capacity,
                    }).ToList();
            }
            return filteredLinesOrMachines;
        }

        /// <summary>
        /// Create new for FactoryCapacity
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pf"></param>
        /// <param name="standingCapacity"></param>
        /// <param name="capacityColors"></param>
        /// <returns></returns>
        private static FactoryCapacity CreateFactoryCapacity(DateTime date, PlanningGroupFactoryDto pf,
            decimal standingCapacity, ColorStripSchedulePlanningDetail colorStripSchedulePlanningDetail, int processId)
        {
            var factoryCapacity = new FactoryCapacity
            {
                Date = date.Date,
                PlanningGroupFactoryId = pf.Id,
                FactoryId = pf.FactoryId,
                FactoryName = pf.FactoryName,
                ProcessId = processId,
                ProcessName = pf.ProcessName,
                Standingcapacity = standingCapacity,
                ActualCapacity = CalculateActualCapacity(date, colorStripSchedulePlanningDetail.StripSchedulePlanningDetails)
            };

            factoryCapacity.Percent = CalculatePercent(factoryCapacity.ActualCapacity, factoryCapacity.Standingcapacity);
            factoryCapacity.ColorCode = DetermineColorCode(factoryCapacity.Percent, colorStripSchedulePlanningDetail.CapacityColors);
            return factoryCapacity;
        }

        /// <summary>
        /// Update Capacity
        /// </summary>
        /// <param name="fc"></param>
        /// <param name="standingCapacity"></param>
        /// <param name="capacityColors"></param>
        private static FactoryCapacity UpdateFactoryCapacity(DateTime date, FactoryCapacity factoryCapacity, decimal standingCapacity,
            ColorStripSchedulePlanningDetail colorStripSchedulePlanningDetail)
        {
            factoryCapacity.Standingcapacity = standingCapacity;
            factoryCapacity.ActualCapacity = CalculateActualCapacity(date, colorStripSchedulePlanningDetail.StripSchedulePlanningDetails);
            factoryCapacity.Percent = CalculatePercent(factoryCapacity.ActualCapacity, factoryCapacity.Standingcapacity);
            factoryCapacity.ColorCode = DetermineColorCode(factoryCapacity.Percent, colorStripSchedulePlanningDetail.CapacityColors);

            return factoryCapacity;
        }

        /// <summary>
        /// Calculate percent
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="standing"></param>
        /// <returns></returns>
        private static decimal? CalculatePercent(decimal? actual, decimal? standing)
        {
            return actual / standing.ValueIgnoreZero();
        }

        /// <summary>
        /// Check color
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="capacityColors"></param>
        /// <returns></returns>
        private static string DetermineColorCode(decimal? percent, IReadOnlyList<CapacityColor> capacityColors)
        {
            return capacityColors.FirstOrDefault(x => x.FromRange <= percent && x.ToRange >= percent)?.Color;
        }

        /// <summary>
        /// Calculate actual capacity for line
        /// </summary>
        /// <param name="plRowId"></param>
        /// <param name="stripSchedules"></param>
        /// <returns></returns>
        private static decimal CalculateActualCapacity(DateTime date, IReadOnlyList<StripSchedulePlanningDetail> stripSchedulePlanningDetails)
        {
            return stripSchedulePlanningDetails
                   .Where(x => x.Date.Date == date.Date)
                   .GroupBy(x => x.Date.Date)
                   .Sum(g => g.Sum(x => x.ActualCapacity));
        }


        /// <summary>
        /// Calculate capacity for line
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        private static decimal CalculateCapacityForLine(int? worker, decimal hour)
        {
            return (worker ?? 0) * hour;
        }

        /// <summary>
        /// Capacity for Machine
        /// </summary>
        /// <param name="capacityMachine"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        private static decimal CalculateCapacityForMachine(decimal? capacityMachine, decimal hour)
        {
            return (capacityMachine ?? 0) * hour;
        }
    }
}