using MediatR;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Application.Models.LineMachineCapacities;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.LineMachineCapacities
{
    public class CalculateLineMachineCapacitiesCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PlanningGroupId { get; set; }
    }
    public class CalculateLineMachineCapacitiesHandler : IRequestHandler<CalculateLineMachineCapacitiesCommand, Core.Models.Responses.Response<bool>>
    {
        private readonly ILineMachineCapacityRepository _lineMachineCapacityRepository;
        private readonly IRequestClientService _requestClientService;

        public CalculateLineMachineCapacitiesHandler(
            ILineMachineCapacityRepository lineMachineCapacityRepository,
            IRequestClientService requestClientService)
        {
            _lineMachineCapacityRepository = lineMachineCapacityRepository;
            _requestClientService = requestClientService;
        }

        public async Task<Core.Models.Responses.Response<bool>> Handle(CalculateLineMachineCapacitiesCommand request, CancellationToken cancellationToken)
        {
            #region ValidData

            var planningGroup =
                await _requestClientService.GetResponseAsync<GetPlanningGroupByIdRequest, GetPlanningGroupByIdResponse>(
                    new() { Id = request.PlanningGroupId }, cancellationToken);

            // Check if factory processes exist
            if (planningGroup?.Message == null)
                return new($"PlanningGroupRes not found");

            #endregion

            #region Globals

            // Lines/Machines/Calendar form master
            var factoryIds = planningGroup.Message?.PlanningGroupFactories?.Select(x => x.FactoryId).ToList();

            var linesResponse = await _requestClientService.GetResponseAsync<GetLinesRequest, GetLinesResponse>(new(), cancellationToken);
            var lines = linesResponse?.Message?.Data.Where(x => x.ProcessId == planningGroup?.Message?.ProcessId && factoryIds.Contains(x.FactoryId.Value)).ToList();

            var machinesResponse = await _requestClientService.GetResponseAsync<GetMachinesRequest, GetMachinesResponse>(new(), cancellationToken);
            var machines = machinesResponse?.Message?.Data.Where(x => x.ProcessId == planningGroup?.Message?.ProcessId && factoryIds.Contains(x.FactoryId.Value)).ToList();

            var calendarResponse = await _requestClientService.GetResponseAsync<GetCalendarByIdRequest, GetCalendarByIdResponse>(new() { Id = planningGroup.Message.CalendarId }, cancellationToken);
            var holidayResponse = await _requestClientService.GetResponseAsync<GetHolidaysRequest, GetHolidaysResponse>(new(), cancellationToken);

            #endregion

            #region Logic

            // Data from factoryCapacities
            var lineMachineCapacities = await _lineMachineCapacityRepository.GetLineMachineCapacityByDate(
                request.FromDate.Value.Date, request.ToDate.Value.Date, lines.Select(x => x.Id).ToList(), machines.Select(x => x.Id).ToList());
            // Get lines or machines
            var mapLineOrMachines = GetFilterLinesOrMachines(lines, machines);
            // Calculate factory capacities
            var tempCapacities = CalculateLineMachineCapacities(calendarResponse?.Message, mapLineOrMachines, request.FromDate, request.ToDate);

            var lstLineMachineCapacity = new List<LineMachineCapacity>();
            foreach (var item in tempCapacities)
            {
                var holiday = holidayResponse?.Message?.Data?.FirstOrDefault(x => x.Date != null && x.Date.Value.Date == item.Day);
                item.WorkingHours = holiday == null ? item.WorkingHours : 0;

                var lineMachineObject = lineMachineCapacities.FirstOrDefault(x =>
                    (x.LineId == item.LineId || (item.LineId == null && x.MachineId == item.MachineId)) &&
                    x.Date == item.Day);
                lineMachineObject = lineMachineObject != null ? UpdateLineMachineCapacity(lineMachineObject, item)
                    : CreateLineMachineCapacity(item);
                lstLineMachineCapacity.Add(lineMachineObject);
            }

            #endregion

            #region SaveChanges

            // Save data for LineMachineCapacity
            var result = await _lineMachineCapacityRepository.SaveLineMachineCapacitySync(lstLineMachineCapacity);
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
        public static List<LineMachineCapacityTermStadingCapacity> CalculateLineMachineCapacities(GetCalendarByIdResponse calendar,
            List<LineOrMachineMapModel> lineOrMachineResponse, DateTime? fDate, DateTime? tDate)
        {
            var lineMachineCapacities = new List<LineMachineCapacityTermStadingCapacity>();

            foreach (var item in lineOrMachineResponse)
            {
                DateTime currentDate = fDate.GetValueOrDefault();
                while (currentDate <= tDate)
                {
                    var timeOnly = GetTimeOnlyForDay(calendar, currentDate);

                    decimal standingCapacity = CalculateStandingCapacity(item, timeOnly);
                    lineMachineCapacities.Add(new LineMachineCapacityTermStadingCapacity
                    {
                        Day = currentDate.Date,
                        DayOfWeek = currentDate.DayOfWeek.ToString(),
                        StandingCapacity = standingCapacity,
                        LineId = item.LineId,
                        MachineId = item.MachineId,
                        LineName = item.LineName,
                        MachineName = item.MachineName,
                        WorkingHours = timeOnly
                    });

                    currentDate = currentDate.AddDays(1);
                }
            }

            return lineMachineCapacities;
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
            return dayDetail?.WorkingHours;
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
                ? CalculateCapacityForLine(item.Worker, timeOnly ?? 0)
                : CalculateCapacityForMachine(item.CapacityMachine, timeOnly ?? 0);
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
                    LineName = x.Name,
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
                        MachineName = x.Name,
                        CapacityMachine = x.Capacity,
                    }).ToList();
            }
            return filteredLinesOrMachines;
        }

        /// <summary>
        /// Create new for LineMachineCapacity
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pf"></param>
        /// <param name="standingCapacity"></param>
        /// <param name="capacityColors"></param>
        /// <returns></returns>
        private static LineMachineCapacity CreateLineMachineCapacity(LineMachineCapacityTermStadingCapacity item)
        {
            var LineMachineCapacity = new LineMachineCapacity
            {
                MachineId = item.MachineId,
                MachineName = item.MachineName,
                LineId = item.LineId,
                LineName = item.LineName,
                Date = item.Day,
                Standingcapacity = item.StandingCapacity,
                WorkingHours = item.WorkingHours
            };

            return LineMachineCapacity;
        }

        /// <summary>
        /// Update Capacity
        /// </summary>
        /// <param name="fc"></param>
        /// <param name="standingCapacity"></param>
        /// <param name="capacityColors"></param>
        private static LineMachineCapacity UpdateLineMachineCapacity(LineMachineCapacity lineMachineCapacity, LineMachineCapacityTermStadingCapacity item)
        {
            lineMachineCapacity.Standingcapacity = item.StandingCapacity;
            lineMachineCapacity.WorkingHours = item.WorkingHours;
            return lineMachineCapacity;
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