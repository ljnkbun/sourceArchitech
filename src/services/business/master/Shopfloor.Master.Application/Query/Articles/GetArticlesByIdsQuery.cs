using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Articles
{
    public class GetArticlesByIdsQuery : IRequest<Response<List<Article>>>
    {
        public List<int> Ids { get; set; }
    }
    public class GetArticlesByIdsQueryHandler : IRequestHandler<GetArticlesByIdsQuery, Response<List<Article>>>
    {
        private readonly IArticleRepository _repository;
        public GetArticlesByIdsQueryHandler(IArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<List<Article>>> Handle(GetArticlesByIdsQuery query, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetArticlesByIdsAsync(query.Ids);
            if (entities == null) return new($"Article Not Found.");
            return new Response<List<Article>>(entities);
        }
    }
}
