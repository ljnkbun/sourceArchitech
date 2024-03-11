using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Calendars;

namespace Shopfloor.Master.Api.Consumers.Requests.Calendars
{
    public class GetCalendarsRequestConsumer : IConsumer<GetCalendarsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCalendarsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCalendarsRequest> context)
        {
            Log.Warning($"GetCalendarsRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetCalendarsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetCalendarsResponse
            {
                Data = structures.Data.Select(x => new GetCalendarByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CalendarDetails = x.CalendarDetails?.Select(x=> new CalendarDetail()
                    {
                        CalendarId = x.CalendarId,
                        BreakHours = x.BreakHours,
                        DayOfWeek = x.DayOfWeek,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        WorkingHours = x.WorkingHours
                    }).ToList(),
                }).ToList()
            };
            Log.Information($"GetCalendarsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
