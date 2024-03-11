using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ProductGroupUOMs;
using Shopfloor.Master.Application.Parameters.ProductGroupUOMs;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ProductGroupUOMs
{
    public class GetProductGroupUOMsQuery : IRequest<PagedResponse<IReadOnlyList<ProductGroupUOMModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public int? UOMId { get; set; }
        public int? ProductGroupId { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProductGroupUOMs";
        public TimeSpan? SlidingExpiration { get; set; }
    }

    public class GetProductGroupUOMsQueryHandler : IRequestHandler<GetProductGroupUOMsQuery, PagedResponse<IReadOnlyList<ProductGroupUOMModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductGroupUOMRepository _repository;

        public GetProductGroupUOMsQueryHandler(IMapper mapper,
            IProductGroupUOMRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProductGroupUOMModel>>> Handle(GetProductGroupUOMsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProductGroupUOMParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ProductGroupUOMParameter, ProductGroupUOMModel>(validFilter);
        }
    }
}