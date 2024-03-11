using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturing4PointSyss
{
    public class GetInspectionDefectCapturing4PointSyssQuery : IRequest<PagedResponse<IReadOnlyList<InspectionDefectCapturing4PointSysModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? Inpection4PointSysId { get; set; }
		public int? QCDefectId { get; set; }
		public int? DefectQtyOne { get; set; }
		public int? DefectQtyTwo { get; set; }
		public int? DefectQtyThree { get; set; }
		public int? DefectQtyFour { get; set; }
		public int? MinorOne { get; set; }
		public int? MinorTwo { get; set; }
		public int? MinorThree { get; set; }
		public int? MinorFour { get; set; }
		public int? MajorOne { get; set; }
		public int? MajorTwo { get; set; }
		public int? MajorThree { get; set; }
		public int? MajorFour { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInspectionDefectCapturing4PointSyssQueryHandler : IRequestHandler<GetInspectionDefectCapturing4PointSyssQuery, PagedResponse<IReadOnlyList<InspectionDefectCapturing4PointSysModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturing4PointSysRepository _repository;
        public GetInspectionDefectCapturing4PointSyssQueryHandler(IMapper mapper,
            IInspectionDefectCapturing4PointSysRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionDefectCapturing4PointSysModel>>> Handle(GetInspectionDefectCapturing4PointSyssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionDefectCapturing4PointSysParameter>(request);
            return await _repository.GetModelSingleQueryPagedReponseAsync<InspectionDefectCapturing4PointSysParameter, InspectionDefectCapturing4PointSysModel>(validFilter);
        }
    }
}
