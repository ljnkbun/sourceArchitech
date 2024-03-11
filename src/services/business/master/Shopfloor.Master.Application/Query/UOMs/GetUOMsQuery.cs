using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.UOMs;
using Shopfloor.Master.Application.Parameters.UOMs;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.UOMs
{
    public class GetUOMsQuery : IRequest<PagedResponse<IReadOnlyList<UOMModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ArticleId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int? DecimalPlaces { get; set; }
        public int? OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
        public string ArticleCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"UOMs";
        public TimeSpan? SlidingExpiration { get; set; }
    }

    public class GetUOMsQueryHandler : IRequestHandler<GetUOMsQuery, PagedResponse<IReadOnlyList<UOMModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUOMRepository _repository;

        public GetUOMsQueryHandler(IMapper mapper,
            IUOMRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<UOMModel>>> Handle(GetUOMsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<UOMParameter>(request);
            return await _repository.GetUOMPagedResponseAsync<UOMParameter, UOMModel>(validFilter, request.ArticleId, request.ArticleCode);
        }
    }
}