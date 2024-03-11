using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingOperationInputArticles;
using Shopfloor.IED.Application.Parameters.WeavingOperationInputArticles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingOperationInputArticles
{
    public class GetWeavingOperationInputArticlesQuery : IRequest<PagedResponse<IReadOnlyList<WeavingOperationInputArticleModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingOperationId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetWeavingOperationInputArticlesQueryHandler : IRequestHandler<GetWeavingOperationInputArticlesQuery, PagedResponse<IReadOnlyList<WeavingOperationInputArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingOperationInputArticleRepository _repository;

        public GetWeavingOperationInputArticlesQueryHandler(IMapper mapper,
            IWeavingOperationInputArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingOperationInputArticleModel>>> Handle(GetWeavingOperationInputArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingOperationInputArticleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingOperationInputArticleParameter, WeavingOperationInputArticleModel>(validFilter);
        }
    }
}