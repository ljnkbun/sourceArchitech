using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ExportArticles;
using Shopfloor.Barcode.Application.Parameters.ExportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ExportArticles
{
    public class GetExportArticlesQuery : IRequest<PagedResponse<IReadOnlyList<ExportArticleModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }

        public int? ExportId { get; set; }
        public int? ArticleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SourceASNNo { get; set; }
        public string Supplier { get; set; }
        public string Buyer { get; set; }
        public ItemStatus? Status { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetExportArticleEntitiesQueryHandler : IRequestHandler<GetExportArticlesQuery, PagedResponse<IReadOnlyList<ExportArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IExportArticleRepository _repository;
        public GetExportArticleEntitiesQueryHandler(IMapper mapper,
            IExportArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ExportArticleModel>>> Handle(GetExportArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ExportArticleParameter>(request);

            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            return await _repository.GetModelPagedReponseAsync<ExportArticleParameter, ExportArticleModel>(validFilter);
        }
    }
}
