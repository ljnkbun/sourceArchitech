using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ImportArticles;
using Shopfloor.Barcode.Application.Parameters.ImportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;


namespace Shopfloor.Barcode.Application.Query.ImportArticles
{
    public class GetImportArticlesQuery : IRequest<PagedResponse<IReadOnlyList<ImportArticleModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int? Id { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string GDNNumber { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string SupplierName { get; set; }
        public string OrderRefNum { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public string UOM { get; set; }
        public decimal? Units { get; set; }
        public string OCNum { get; set; }
        public ItemStatus? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
      
    }
    public class GetImportArticlesQueryHandler : IRequestHandler<GetImportArticlesQuery, PagedResponse<IReadOnlyList<ImportArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IImportArticleRepository _repository;
        public GetImportArticlesQueryHandler(IMapper mapper,
            IImportArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ImportArticleModel>>> Handle(GetImportArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ImportArticleParameter>(request);

            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            return await _repository.GetModelPagedReponseAsync<ImportArticleParameter, ImportArticleModel>(validFilter);
        }
    }
}
