using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturing100PointSyss
{
    public class GetInspectionDefectCapturing100PointSyssQuery : IRequest<PagedResponse<IReadOnlyList<InspectionDefectCapturing100PointSysModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? Inpection100PointSysId { get; set; }
		public int? QCDefectId { get; set; }
		public int? Minor { get; set; }
		public int? Major { get; set; }
		public int? Critial { get; set; }
		public int? AttachmentId { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
		public string Remark { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"InspectionDefectCapturing100PointSys";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetInspectionDefectCapturing100PointSyssQueryHandler : IRequestHandler<GetInspectionDefectCapturing100PointSyssQuery, PagedResponse<IReadOnlyList<InspectionDefectCapturing100PointSysModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturing100PointSysRepository _repository;
        public GetInspectionDefectCapturing100PointSyssQueryHandler(IMapper mapper,
            IInspectionDefectCapturing100PointSysRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionDefectCapturing100PointSysModel>>> Handle(GetInspectionDefectCapturing100PointSyssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionDefectCapturing100PointSysParameter>(request);
            return await _repository.GetModelSingleQueryPagedReponseAsync<InspectionDefectCapturing100PointSysParameter, InspectionDefectCapturing100PointSysModel>(validFilter);
        }
    }
}
