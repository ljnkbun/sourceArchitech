using AutoMapper;
using MediatR;
using Shopfloor.Planning.Application.Models.StripFactorySchedules;
using Shopfloor.Planning.Application.Parameters.StripFactorySchedules;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.StripFactorySchedules
{
    public class GetStripFactorySchedulesQuery : IRequest<PagedResponse<IReadOnlyList<StripFactoryScheduleModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNo { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"StripFactorySchedule";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetStripFactorySchedulesQueryHandler : IRequestHandler<GetStripFactorySchedulesQuery, PagedResponse<IReadOnlyList<StripFactoryScheduleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryScheduleRepository _repository;
        public GetStripFactorySchedulesQueryHandler(IMapper mapper,
            IStripFactoryScheduleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripFactoryScheduleModel>>> Handle(GetStripFactorySchedulesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripFactoryScheduleParameter>(request);
            return await _repository.GetStripFactoryScheduleModelPagedReponseAsync<StripFactoryScheduleParameter, StripFactoryScheduleModel>(validFilter);
        }
    }
}
