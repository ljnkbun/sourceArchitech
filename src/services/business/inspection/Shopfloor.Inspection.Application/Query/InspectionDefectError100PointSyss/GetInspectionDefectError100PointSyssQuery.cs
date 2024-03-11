using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectError100PointSyss
{
    public class GetInspectionDefectError100PointSyssQuery : IRequest<PagedResponse<IReadOnlyList<InspectionDefectError100PointSysModel>>>
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
    public class GetInspectionDefectError100PointSyssQueryHandler : IRequestHandler<GetInspectionDefectError100PointSyssQuery, PagedResponse<IReadOnlyList<InspectionDefectError100PointSysModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectError100PointSysRepository _repository;
        public GetInspectionDefectError100PointSyssQueryHandler(IMapper mapper,
            IInspectionDefectError100PointSysRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionDefectError100PointSysModel>>> Handle(GetInspectionDefectError100PointSyssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionDefectError100PointSysParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionDefectError100PointSysParameter, InspectionDefectError100PointSysModel>(validFilter);
        }
    }
}
