using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Calendars;

namespace Shopfloor.Master.Api.Consumers.Requests.Calendars
{
    public class GetCalendarByIdRequestConsumer : IConsumer<GetCalendarByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCalendarByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCalendarByIdRequest> context)
        {
            Log.Warning($"GetCalendarByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetCalendarQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetCalendarByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                CalendarDetails = structures.Data.CalendarDetails?.Select(x => new CalendarDetail()
                {
                    CalendarId = x.CalendarId,
                    BreakHours = x.BreakHours,
                    DayOfWeek = x.DayOfWeek,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    WorkingHours = x.WorkingHours
                }).ToList()
            };
            Log.Information($"GetCalendarByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
