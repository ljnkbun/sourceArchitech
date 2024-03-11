using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Articles;
using Shopfloor.Master.Application.Parameters.Articles;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Articles
{
    public class GetArticlesQuery : IRequest<PagedResponse<IReadOnlyList<ArticleModel>>>, ICacheableMediatrQuery
    {
        public int? WFXArticleId { get; set; }
        public string Category { get; set; }
        public string MaterialType { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDesc { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public string FabricMaterial { get; set; }
        public string OurContact { get; set; }
        public string PurchaseUOM { get; set; }
        public string StoringUOM { get; set; }
        public string DivisionName { get; set; }
        public string ConsumptionUOM { get; set; }
        public string ColorCard { get; set; }
        public string SizeWidthRange { get; set; }
        public decimal? MinimumQty { get; set; }
        public decimal? MaximumQty { get; set; }
        public string Buyer { get; set; }
        public string RestrictedItem { get; set; }
        public string Supplier { get; set; }
        public string Brand { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string BuyingCurrencyCode { get; set; }
        public string PricePer { get; set; }
        public string PerSizeCons { get; set; }
        public decimal? OrderQtyMultiple { get; set; }
        public string Season { get; set; }
        public string BuyerStyleRef { get; set; }
        public string Gender { get; set; }
        public string ColorDefinition { get; set; }
        public decimal? SAM { get; set; }
        public decimal? SellingPrice { get; set; }
        public string SellingPriceCurrency { get; set; }
        public string BuyerDepartmentName { get; set; }
        public string HSCode { get; set; }
        public string StyleType { get; set; }
        public string Reference { get; set; }
        public string ModelNo { get; set; }
        public string MYear { get; set; }
        public string PackingTypeName { get; set; }
        public string StockTypeName { get; set; }
        public decimal? ReOrderLevel { get; set; }
        public decimal? MinimumOrderQty { get; set; }
        public decimal? RequirementMultiple { get; set; }
        public bool? UseForIED { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        #region Default
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
        public string CacheKey => $"Articles";
        public TimeSpan? SlidingExpiration { get; set; }
        #endregion

    }
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, PagedResponse<IReadOnlyList<ArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _repository;
        public GetArticlesQueryHandler(IMapper mapper,
            IArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ArticleModel>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ArticleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ArticleParameter, ArticleModel>(validFilter);
        }
    }
}
