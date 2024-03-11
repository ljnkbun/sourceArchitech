using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.Inspections;
using Shopfloor.Inspection.Application.Parameters.Inspections;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.Inspections
{
    public class GetInspectionsQuery : IRequest<PagedResponse<IReadOnlyList<InspectionModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? InspectionDate { get; set; }
		public int? QCRequestArticleId { get; set; }
		public bool? DefaultResult { get; set; }
		public bool? UserResult { get; set; }
		public bool? MeasurementResult { get; set; }
		public decimal? MeasurementQty { get; set; }
		public decimal? InspectionQty { get; set; }
		public string Reason { get; set; }
		public string Remark { get; set; }
		public string Line { get; set; }
		public decimal? TotalDefect { get; set; }
		public string Stage { get; set; }
		public string CuttingTable { get; set; }
		public bool? IsCreatedFromProduction { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInspectionsQueryHandler : IRequestHandler<GetInspectionsQuery, PagedResponse<IReadOnlyList<InspectionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionRepository _repository;
        public GetInspectionsQueryHandler(IMapper mapper,
            IInspectionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionModel>>> Handle(GetInspectionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionParameter>(request);
            return await _repository.GetModelSingleQueryPagedReponseAsync<InspectionParameter, InspectionModel>(validFilter);
        }
    }
}
