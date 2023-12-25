using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingArticles
{
    public class GetWeavingArticleQuery : IRequest<Response<WeavingArticle>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingArticleQueryHandler : IRequestHandler<GetWeavingArticleQuery, Response<WeavingArticle>>
    {
        private readonly IWeavingArticleRepository _repository;
        public GetWeavingArticleQueryHandler(IWeavingArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingArticle>> Handle(GetWeavingArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"WeavingArticle Not Found (Id:{query.Id}).");
            return new Response<WeavingArticle>(entity);
        }
    }
}
