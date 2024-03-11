using MediatR;
using Microsoft.Extensions.Options;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Master.Application.Settings;
using Shopfloor.Master.Domain.Enums;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CalendarDetails
{
    public class UpdateCalendarDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal BreakHours { get; set; }
        public int CalendarId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateCalendarDetailCommandHandler : IRequestHandler<UpdateCalendarDetailCommand, Response<int>>
    {
        private readonly ICalendarDetailRepository _repository;
        private readonly MassTransit.IPublishEndpoint _publishEndpoint;
        private readonly CalculateFactoryCapacityApiSettings _settings;
        public UpdateCalendarDetailCommandHandler(ICalendarDetailRepository repository,
            MassTransit.IPublishEndpoint publishEndpoint,
            IOptions<CalculateFactoryCapacityApiSettings> setting)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _settings = setting.Value;
        }
        public async Task<Response<int>> Handle(UpdateCalendarDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"CalendarDetail Not Found.");
            var oldWorkingHour = entity.WorkingHours;

            entity.DayOfWeek = command.DayOfWeek;
            entity.Shift = command.Shift;
            entity.StartTime = command.StartTime;
            entity.EndTime = command.EndTime;
            entity.WorkingHours = command.WorkingHours;
            entity.BreakHours = command.BreakHours;
            entity.CalendarId = command.CalendarId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);

            if (command.WorkingHours != oldWorkingHour)
            {
                //Call calculate factory capacity
                await CallFactoryCapacity(cancellationToken);
            }

            return new Response<int>(entity.Id);
        }

        private async Task CallFactoryCapacity(CancellationToken cancellationToken)
        {
            var fDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var tDate = fDate.AddMonths(_settings.Month);
            await _publishEndpoint.Publish(new CalculateFactoryCapacityMessage()
            {
                FromDate = fDate,
                ToDate = tDate
            }, cancellationToken);
        }
    }
}
