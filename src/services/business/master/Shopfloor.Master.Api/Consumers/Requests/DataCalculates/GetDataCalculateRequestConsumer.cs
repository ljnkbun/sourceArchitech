using MassTransit;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;
using Log = Serilog.Log;

namespace Shopfloor.Master.Api.Consumers.Requests.Calendars
{
    public class GetDataCalculateRequestConsumer : IConsumer<GetDataCalculateRequest>
    {
        #region Initialization

        private readonly IPlanningGroupRepository _planningGroup;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly ILineRepository _lineRepository;

        public GetDataCalculateRequestConsumer(
            ICalendarRepository calendarRepository,
            IMachineRepository machineRepository,
            ILineRepository lineRepository,
            IPlanningGroupRepository planningGroup)
        {
            _lineRepository = lineRepository;
            _machineRepository = machineRepository;
            _calendarRepository = calendarRepository;
            _planningGroup = planningGroup;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDataCalculateRequest> context)
        {
            Log.Warning($"GetDataCalculatesRequestConsumer: request={context.Message.ToJson()}");


            var planningGroup = await _planningGroup.GetByIdAsync(context.Message.PlanningGroupId);
            var dataCalendar = await _calendarRepository.GetByIdAsync(planningGroup.CalendarId);
            var dataMachine = await _machineRepository.GetByIdAsync((int)context.Message.MachineId);
            var dataLine = await _lineRepository.GetByIdAsync((int)context.Message.LineId);

            var response = new GetDataCalculateResponse()
            {
                Machine = dataMachine != null ? new MachineDto()
                {
                    SerialNo = dataMachine.SerialNo,
                    Remarks = dataMachine.Remarks,
                    Capacity = dataMachine.Capacity,
                    FactoryId = dataMachine.FactoryId,
                    ProcessId = dataMachine.ProcessId,
                    Gauge = dataMachine.Gauge,
                    MachineDiameter = dataMachine.MachineDiameter
                } : null,
                Line = dataLine != null ? new LineDto()
                {
                    Code = dataLine.Code,
                    Name = dataLine.Name,
                    Worker = dataLine.Worker,
                    WFXLineId = dataLine.WFXLineId,
                    FactoryId = dataLine.FactoryId,
                    ProcessId = dataLine.ProcessId
                } : null,
                CalendarDetails = dataCalendar.CalendarDetails?.Select(x => new CalendarDetailDto()
                {
                    CalendarId = x.CalendarId,
                    BreakHours = x.BreakHours,
                    DayOfWeek = x.DayOfWeek,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    WorkingHours = x.WorkingHours
                }).ToList()
            };
            Log.Information($"GetDataCalculatesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
