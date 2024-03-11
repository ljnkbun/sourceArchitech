using AutoMapper;
using MediatR;
using Shopfloor.Master.Application.Models.Holidays;
using Shopfloor.Master.Application.Parameters.Holidays;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Master.Application.Query.Holidays
{
    public class GetHolidaysQuery : IRequest<PagedResponse<IReadOnlyList<HolidayModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
		public string Description { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Holiday";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetHolidaysQueryHandler : IRequestHandler<GetHolidaysQuery, PagedResponse<IReadOnlyList<HolidayModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IHolidayRepository _repository;
        public GetHolidaysQueryHandler(IMapper mapper,
            IHolidayRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<HolidayModel>>> Handle(GetHolidaysQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<HolidayParameter>(request);
            return await _repository.GetHolidayModelPagedReponseAsync<HolidayParameter, HolidayModel>(validFilter, request.FromDate, request.ToDate);
        }
    }
}
