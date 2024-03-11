using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Enums;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CalendarDetails
{
    public class CreateCalendarDetailCommand : IRequest<Response<int>>
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal BreakHours { get; set; }
        public int CalendarId { get; set; }
    }
    public class CreateCalendarDetailCommandHandler : IRequestHandler<CreateCalendarDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarDetailRepository _repository;
        public CreateCalendarDetailCommandHandler(IMapper mapper,
            ICalendarDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCalendarDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CalendarDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
