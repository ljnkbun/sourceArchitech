using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.ProblemTimelines;
using Shopfloor.Inspection.Application.Parameters.ProblemTimelines;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.ProblemTimelines
{
    public class GetProblemTimelinesQuery : IRequest<PagedResponse<IReadOnlyList<ProblemTimelineModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string NameVN { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int? SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public InspectionType? InspectionType { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProblemTimelines";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProblemTimelinesQueryHandler : IRequestHandler<GetProblemTimelinesQuery, PagedResponse<IReadOnlyList<ProblemTimelineModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProblemTimelineRepository _repository;
        public GetProblemTimelinesQueryHandler(IMapper mapper,
            IProblemTimelineRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProblemTimelineModel>>> Handle(GetProblemTimelinesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProblemTimelineParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ProblemTimelineParameter, ProblemTimelineModel>(validFilter);
        }
    }
}
