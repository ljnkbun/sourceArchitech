using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Application.Parameters.WfxPOArticles;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxPOArticles
{
    public class GetWfxPOArticlesQuery : IRequest<PagedResponse<IReadOnlyList<WfxPOArticleParentModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }

        public OrderTypes? OrderType { get; set; } = OrderTypes.PO;
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public string OrderRefNum { get; set; }
        public string SupplierName { get; set; }
        public string ArticleCode { get; set; }
        public ArticleTypes? ArticleType { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetWfxPOArticleEntitiesQueryHandler : IRequestHandler<GetWfxPOArticlesQuery, PagedResponse<IReadOnlyList<WfxPOArticleParentModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxPOArticleRepository _repository;
        public GetWfxPOArticleEntitiesQueryHandler(IMapper mapper,
            IWfxPOArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxPOArticleParentModel>>> Handle(GetWfxPOArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxPOArticleParameter>(request);
            validFilter.OrderType = validFilter.OrderType.ToString();
            validFilter.ArticleType = validFilter.ArticleTypes.ToString();
            var rs = await _repository.GetListAsync<WfxPOArticleParameter, WfxPOArticleMasterModel>(validFilter, validFilter.FromOrderDate, validFilter.ToOrderDate);

            if (rs.Data == null) return _mapper.Map<PagedResponse<IReadOnlyList<WfxPOArticleParentModel>>>(rs);

            var response = new PagedResponse<IReadOnlyList<WfxPOArticleParentModel>>(validFilter.PageNumber, validFilter.PageSize);
            var groupByData = rs.Data.GroupBy(x => new { x.ArticleCode, x.OrderRefNum });

            var respData = new List<WfxPOArticleParentModel>();

            foreach (var entry in groupByData)
            {
                var articleModele = _mapper.Map<WfxPOArticleParentModel>(entry.FirstOrDefault());
                respData.Add(articleModele);

                var lstEntityModel = rs.Data.Where(x => x.ArticleCode == entry.Key.ArticleCode && x.OrderRefNum == entry.Key.OrderRefNum);
                if (lstEntityModel.Any())
                {
                    articleModele.WfxPOArticleChildModels = _mapper.Map<List<WfxPOArticleChildModel>>(lstEntityModel);
                }
            }

            response.Data = respData;

            return response;
        }
    }
}
