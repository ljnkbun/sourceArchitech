using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingYarns;
using Shopfloor.IED.Application.Parameters.WeavingYarns;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingYarns
{
    public class GetWeavingYarnsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingYarnModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingArticleId { get; set; }
        public int? LineNumber { get; set; }
        public YarnType? YarnType { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public decimal? YarnInRappo { get; set; }
        public decimal? YarnRatio { get; set; }
        public decimal? SizingRatio { get; set; }
        public decimal? ScaleRatio { get; set; }
        public decimal? ScrapRatio { get; set; }
        public decimal? Weight { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"WeavingYarns";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingYarnsQueryHandler : IRequestHandler<GetWeavingYarnsQuery, PagedResponse<IReadOnlyList<WeavingYarnModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingYarnRepository _repository;
        public GetWeavingYarnsQueryHandler(IMapper mapper,
            IWeavingYarnRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingYarnModel>>> Handle(GetWeavingYarnsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingYarnParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingYarnParameter, WeavingYarnModel>(validFilter);
        }
    }
}
