using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.CalendarDetails;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Calendars
{
    public class CreateCalendarCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<CreateCalendarDetailCommand> CalendarDetails { get; set; }
    }
    public class CreateCalendarCommandHandler : IRequestHandler<CreateCalendarCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _repository;
        public CreateCalendarCommandHandler(IMapper mapper,
            ICalendarRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Calendar>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
