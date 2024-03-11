using AutoMapper;
using MediatR;
using Shopfloor.Planning.Application.Models.StripFactoryScheduleDetails;
using Shopfloor.Planning.Application.Parameters.StripFactoryScheduleDetails;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.StripFactoryScheduleDetails
{
    public class GetStripFactoryScheduleDetailsQuery : IRequest<PagedResponse<IReadOnlyList<StripFactoryScheduleDetailModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public decimal Quantity { get; set; }
        public int StripFactoryScheduleId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"StripFactoryScheduleDetail";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetStripFactoryScheduleDetailsQueryHandler : IRequestHandler<GetStripFactoryScheduleDetailsQuery, PagedResponse<IReadOnlyList<StripFactoryScheduleDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryScheduleDetailRepository _repository;
        public GetStripFactoryScheduleDetailsQueryHandler(IMapper mapper,
            IStripFactoryScheduleDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripFactoryScheduleDetailModel>>> Handle(GetStripFactoryScheduleDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripFactoryScheduleDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<StripFactoryScheduleDetailParameter, StripFactoryScheduleDetailModel>(validFilter);
        }
    }
}
