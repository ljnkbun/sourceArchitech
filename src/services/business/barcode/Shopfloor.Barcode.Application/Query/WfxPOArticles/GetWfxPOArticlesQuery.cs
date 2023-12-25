using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Application.Parameters.WfxPOArticles;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxPOArticles
{
    public class GetWfxPOArticlesQuery : IRequest<PagedResponse<IReadOnlyList<WfxPOArticleModel>>>
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
        public string WFXArticleCode { get; set; }
        public ArticleTypes? ArticleType { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetWfxPOArticleEntitiesQueryHandler : IRequestHandler<GetWfxPOArticlesQuery, PagedResponse<IReadOnlyList<WfxPOArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxPOArticleRepository _repository;
        public GetWfxPOArticleEntitiesQueryHandler(IMapper mapper,
            IWfxPOArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxPOArticleModel>>> Handle(GetWfxPOArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxPOArticleParameter>(request);
            validFilter.OrderType = validFilter.OrderType.ToString();
            validFilter.ArticleType = validFilter.ArticleTypes.ToString();
            return await _repository.GetListAsync<WfxPOArticleParameter, WfxPOArticleModel>(validFilter, validFilter.FromOrderDate, validFilter.ToOrderDate);
        }
    }
}
