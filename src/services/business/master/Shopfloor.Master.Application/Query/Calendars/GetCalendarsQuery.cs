using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Calendars;
using Shopfloor.Master.Application.Parameters.Calendars;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Calendars
{
    public class GetCalendarsQuery : IRequest<PagedResponse<IReadOnlyList<CalendarModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Calendars";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCalendarsQueryHandler : IRequestHandler<GetCalendarsQuery, PagedResponse<IReadOnlyList<CalendarModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _repository;
        public GetCalendarsQueryHandler(IMapper mapper,
            ICalendarRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CalendarModel>>> Handle(GetCalendarsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CalendarParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CalendarParameter.Code), nameof(CalendarParameter.Name) }.ToList());
            return await _repository.GetCalendarModelAsync<CalendarParameter, CalendarModel>(validFilter);
        }
    }
}
