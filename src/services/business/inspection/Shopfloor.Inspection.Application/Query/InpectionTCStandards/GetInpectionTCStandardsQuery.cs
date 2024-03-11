using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.InpectionTCStandards;
using Shopfloor.Inspection.Application.Parameters.InpectionTCStandards;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InpectionTCStandards
{
    public class GetInpectionTCStandardsQuery : IRequest<PagedResponse<IReadOnlyList<InpectionTCStandardModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? QCRequestArticleId { get; set; }
		public string StockMovementNo { get; set; }
		public string Grade { get; set; }
		public bool? Result { get; set; }
		public int? PersonInChargeId { get; set; }
		public string Remark { get; set; }
        public string OrderBy { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"InpectionTCStandard";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetInpectionTCStandardsQueryHandler : IRequestHandler<GetInpectionTCStandardsQuery, PagedResponse<IReadOnlyList<InpectionTCStandardModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInpectionTCStandardRepository _repository;
        public GetInpectionTCStandardsQueryHandler(IMapper mapper,
            IInpectionTCStandardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InpectionTCStandardModel>>> Handle(GetInpectionTCStandardsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InpectionTCStandardParameter>(request);
            return await _repository.GetModelSingleQueryPagedReponseAsync<InpectionTCStandardParameter, InpectionTCStandardModel>(validFilter);
        }
    }
}
