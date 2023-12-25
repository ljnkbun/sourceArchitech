using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RequestArticleOutputs;
using Shopfloor.IED.Application.Parameters.RequestArticleOutputs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestArticleOutputs
{
    public class GetRequestArticleOutputsQuery : IRequest<PagedResponse<IReadOnlyList<RequestArticleOutputModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestDivisionProcessId { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"RequestArticleOutputs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetRequestArticleOutputsQueryHandler : IRequestHandler<GetRequestArticleOutputsQuery, PagedResponse<IReadOnlyList<RequestArticleOutputModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestArticleOutputRepository _repository;
        public GetRequestArticleOutputsQueryHandler(IMapper mapper,
            IRequestArticleOutputRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestArticleOutputModel>>> Handle(GetRequestArticleOutputsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestArticleOutputParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestArticleOutputParameter, RequestArticleOutputModel>(validFilter);
        }
    }
}
