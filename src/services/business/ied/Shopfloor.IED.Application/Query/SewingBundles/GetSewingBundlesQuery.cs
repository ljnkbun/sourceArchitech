using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingBundles;
using Shopfloor.IED.Application.Parameters.SewingBundles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingBundles
{
    public class GetSewingBundlesQuery : IRequest<PagedResponse<IReadOnlyList<SewingBundleModel>>>, ICacheableMediatrQuery
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingBundles";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetSewingBundlesQueryHandler : IRequestHandler<GetSewingBundlesQuery, PagedResponse<IReadOnlyList<SewingBundleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingBundleRepository _repository;

        public GetSewingBundlesQueryHandler(IMapper mapper,
            ISewingBundleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingBundleModel>>> Handle(GetSewingBundlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingBundleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingBundleParameter, SewingBundleModel>(validFilter);
        }
    }
}