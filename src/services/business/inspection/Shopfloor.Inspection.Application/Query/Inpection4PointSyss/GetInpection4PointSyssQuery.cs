using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.Inpection4PointSyss;
using Shopfloor.Inspection.Application.Parameters.Inpection4PointSyss;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.Inpection4PointSyss
{
    public class GetInpection4PointSyssQuery : IRequest<PagedResponse<IReadOnlyList<Inpection4PointSysModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? QCRequestArticleId { get; set; }
		public string StockMovementNo { get; set; }
		public decimal? CaptureMeter { get; set; }
		public decimal? ActualWeight { get; set; }
		public int? TotalDefect { get; set; }
		public int? TotalContDefect { get; set; }
		public int? TotalPoint { get; set; }
		public int? PointSquareMeter { get; set; }
		public int? WarpDensity { get; set; }
		public int? WeftDensity { get; set; }
		public int? PersonInChargeId { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Remark { get; set; }
		public int? AttachmentId { get; set; }
		public bool? SystemResult { get; set; }
		public bool? UserResult { get; set; }
		public string Grade { get; set; }
		public decimal? WeightGM2 { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInpection4PointSyssQueryHandler : IRequestHandler<GetInpection4PointSyssQuery, PagedResponse<IReadOnlyList<Inpection4PointSysModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInpection4PointSysRepository _repository;
        public GetInpection4PointSyssQueryHandler(IMapper mapper,
            IInpection4PointSysRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<Inpection4PointSysModel>>> Handle(GetInpection4PointSyssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<Inpection4PointSysParameter>(request);
            return await _repository.GetModelSingleQueryPagedReponseAsync<Inpection4PointSysParameter, Inpection4PointSysModel>(validFilter);
        }
    }
}
