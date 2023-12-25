using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Application.Parameters.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodesQuery : IRequest<PagedResponse<IReadOnlyList<ArticleBarcodeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Barcode { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? ParentId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ArticleBarcode";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetArticleBarcodesQueryHandler : IRequestHandler<GetArticleBarcodesQuery, PagedResponse<IReadOnlyList<ArticleBarcodeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleBarcodeRepository _repository;
        public GetArticleBarcodesQueryHandler(IMapper mapper,
            IArticleBarcodeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ArticleBarcodeModel>>> Handle(GetArticleBarcodesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ArticleBarcodeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ArticleBarcodeParameter.CurrentLocationId) , nameof(ArticleBarcodeParameter.Barcode) 
                , nameof(ArticleBarcodeParameter.ParentId)}.ToList());
            return await _repository.GetModelPagedReponseAsync<ArticleBarcodeParameter, ArticleBarcodeModel>(validFilter);
        }
    }
}
