using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturings;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturings
{
    public class GetInspectionDefectCapturingsQuery : IRequest<PagedResponse<IReadOnlyList<InspectionDefectCapturingModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? Minor { get; set; }
		public int? Major { get; set; }
		public int? Critial { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public int? QCDefectId { get; set; }
        public int? InspectionId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInspectionDefectCapturingsQueryHandler : IRequestHandler<GetInspectionDefectCapturingsQuery, PagedResponse<IReadOnlyList<InspectionDefectCapturingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturingRepository _repository;
        public GetInspectionDefectCapturingsQueryHandler(IMapper mapper,
            IInspectionDefectCapturingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionDefectCapturingModel>>> Handle(GetInspectionDefectCapturingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionDefectCapturingParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionDefectCapturingParameter, InspectionDefectCapturingModel>(validFilter);
        }
    }
}
