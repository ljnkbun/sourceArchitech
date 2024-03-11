using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionMesurements;
using Shopfloor.Inspection.Application.Parameters.InspectionMesurements;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionMesurements
{
    public class GetInspectionMesurementsQuery : IRequest<PagedResponse<IReadOnlyList<InspectionMesurementModel>>>
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
        public bool BypassCache { get; set; }
    }
    public class GetInspectionMesurementsQueryHandler : IRequestHandler<GetInspectionMesurementsQuery, PagedResponse<IReadOnlyList<InspectionMesurementModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionMesurementRepository _repository;
        public GetInspectionMesurementsQueryHandler(IMapper mapper,
            IInspectionMesurementRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionMesurementModel>>> Handle(GetInspectionMesurementsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionMesurementParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionMesurementParameter, InspectionMesurementModel>(validFilter);
        }
    }
}
