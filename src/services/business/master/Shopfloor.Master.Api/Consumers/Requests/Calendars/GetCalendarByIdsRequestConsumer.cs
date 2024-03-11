using MassTransit;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Api.Consumers.Requests.PlanningGroups
{
    public class GetCalendarByIdsRequestConsumer : IConsumer<GetCalendarByIdsRequest>
    {
        #region Initialization

        private readonly ICalendarRepository _CalendarRepository;

        public GetCalendarByIdsRequestConsumer(
            ICalendarRepository CalendarRepository)
        {
            _CalendarRepository = CalendarRepository;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCalendarByIdsRequest> context)
        {
            Log.Warning($"GetCalendarByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _CalendarRepository.GetByIds(context.Message.Ids);
            if (structures.Count == 0) await context.RespondAsync(null);

            var response = new GetCalendarByIdsResponse();
            if (structures?.Count > 0)
            {
                response.Calendars = structures.Select(x => new GetCalendarByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CalendarDetails = x.CalendarDetails?.Select(x => new CalendarDetail()
                    {
                        CalendarId = x.CalendarId,
                        BreakHours = x.BreakHours,
                        DayOfWeek = x.DayOfWeek,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        WorkingHours = x.WorkingHours
                    }).ToList()
                }).ToList();
            }

            Log.Information($"GetCalendarByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
