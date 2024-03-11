using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.QCRequests;
using Shopfloor.Inspection.Application.Parameters.QCRequests;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCRequests
{
    public class GetQCRequestsQuery : IRequest<PagedResponse<IReadOnlyList<QCRequestModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
		public DateTime? QCRequestDate { get; set; }
		public string SiteCode { get; set; }
		public string SiteName { get; set; }
		public string SupplierName { get; set; }
		public string QCRequestNo { get; set; }
		public string Category { get; set; }
		public QCRequestStatus? QCRequestStatus { get; set; }
		public TransferStatus? TransferStatus { get; set; }
		public string DocumentNo { get; set; }
        public string ProductionOutputCode { get; set; }
        public string QCDefinitionCode { get; set; }
		public decimal? RequestedQty { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? FromDate{ get; set; }
		public DateTime? ToDate{ get; set; }
    }
    public class GetQCRequestsQueryHandler : IRequestHandler<GetQCRequestsQuery, PagedResponse<IReadOnlyList<QCRequestModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCRequestRepository _repository;
        public GetQCRequestsQueryHandler(IMapper mapper,
            IQCRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCRequestModel>>> Handle(GetQCRequestsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCRequestParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(QCRequestParameter.SiteCode), nameof(QCRequestParameter.SiteName) }.ToList());
            return await _repository.GetWithDetailPagedReponseAsync<QCRequestParameter, QCRequestModel>(validFilter, validFilter.FromDate, validFilter.ToDate);
        }
    }
}
