using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InspectionBySizes;
using Shopfloor.Inspection.Application.Parameters.InspectionBySizes;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionBySizes
{
    public class GetInspectionBySizesQuery : IRequest<PagedResponse<IReadOnlyList<InspectionBySizeModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ColorCode { get; set; }
		public string ColorName { get; set; }
		public string SizeCode { get; set; }
		public string SizeName { get; set; }
		public string Shade { get; set; }
		public string Lot { get; set; }
		public decimal? GRNQty { get; set; }
		public decimal? PreInspectedQty { get; set; }
		public decimal? LotQty { get; set; }
		public decimal? InspectionQty { get; set; }
		public decimal? ActualQty { get; set; }
		public int? NoOfDefect { get; set; }
        public int? QCRequestDetailId { get; set; }
        public int? InspectionId { get; set; }
        public decimal? OKQty { get; set; }
		public decimal? BGroupQty { get; set; }
		public decimal? BGroupUsable { get; set; }
		public decimal? RejectedQty { get; set; }
		public decimal? ExcessShortageQty { get; set; }
		public string ReasonforBGroup { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInspectionBySizesQueryHandler : IRequestHandler<GetInspectionBySizesQuery, PagedResponse<IReadOnlyList<InspectionBySizeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionBySizeRepository _repository;
        public GetInspectionBySizesQueryHandler(IMapper mapper,
            IInspectionBySizeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionBySizeModel>>> Handle(GetInspectionBySizesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionBySizeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionBySizeParameter, InspectionBySizeModel>(validFilter);
        }
    }
}
