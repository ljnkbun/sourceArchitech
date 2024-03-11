using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectError4PointSyss
{
    public class GetInspectionDefectError4PointSyssQuery : IRequest<PagedResponse<IReadOnlyList<InspectionDefectError4PointSysModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType? ErrorType { get; set; }
		public decimal? From { get; set; }
		public decimal? To { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInspectionDefectError4PointSyssQueryHandler : IRequestHandler<GetInspectionDefectError4PointSyssQuery, PagedResponse<IReadOnlyList<InspectionDefectError4PointSysModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectError4PointSysRepository _repository;
        public GetInspectionDefectError4PointSyssQueryHandler(IMapper mapper,
            IInspectionDefectError4PointSysRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionDefectError4PointSysModel>>> Handle(GetInspectionDefectError4PointSyssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionDefectError4PointSysParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionDefectError4PointSysParameter, InspectionDefectError4PointSysModel>(validFilter);
        }
    }
}
