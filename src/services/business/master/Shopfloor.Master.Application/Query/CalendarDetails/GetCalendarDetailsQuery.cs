using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.CalendarDetails;
using Shopfloor.Master.Application.Parameters.CalendarDetails;
using Shopfloor.Master.Domain.Enums;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CalendarDetails
{
    public class GetCalendarDetailsQuery : IRequest<PagedResponse<IReadOnlyList<CalendarDetailModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public Shift? Shift { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public decimal? WorkingHours { get; set; }
        public decimal? BreakHours { get; set; }
        public int? CalendarId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"CalendarDetails";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCalendarDetailsQueryHandler : IRequestHandler<GetCalendarDetailsQuery, PagedResponse<IReadOnlyList<CalendarDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICalendarDetailRepository _repository;
        public GetCalendarDetailsQueryHandler(IMapper mapper,
            ICalendarDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CalendarDetailModel>>> Handle(GetCalendarDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CalendarDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<CalendarDetailParameter, CalendarDetailModel>(validFilter);
        }
    }
}
