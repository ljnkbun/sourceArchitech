using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturingTCStandards
{
    public class GetInspectionDefectCapturingTCStandardsQuery : IRequest<PagedResponse<IReadOnlyList<InspectionDefectCapturingTCStandardModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? InpectionTCStandardId { get; set; }
		public int? QCDefectId { get; set; }
		public int? Defect { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"InspectionDefectCapturingTCStandard";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetInspectionDefectCapturingTCStandardsQueryHandler : IRequestHandler<GetInspectionDefectCapturingTCStandardsQuery, PagedResponse<IReadOnlyList<InspectionDefectCapturingTCStandardModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturingTCStandardRepository _repository;
        public GetInspectionDefectCapturingTCStandardsQueryHandler(IMapper mapper,
            IInspectionDefectCapturingTCStandardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionDefectCapturingTCStandardModel>>> Handle(GetInspectionDefectCapturingTCStandardsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionDefectCapturingTCStandardParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionDefectCapturingTCStandardParameter, InspectionDefectCapturingTCStandardModel>(validFilter);
        }
    }
}
