using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Articles
{
    public class GetArticleByCodeQuery : IRequest<Response<Article>>
    {
        public string Code { get; set; }
    }

    public class GetGetArticleByCodeQueryQueryHandler : IRequestHandler<GetArticleByCodeQuery, Response<Article>>
    {
        private readonly IArticleRepository _repository;

        public GetGetArticleByCodeQueryQueryHandler(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Article>> Handle(GetArticleByCodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetArticleByCodeAsync(query.Code);
            if (entity == null) return new($"Article Not Found (Code:{query.Code}).");
            return new Response<Article>(entity);
        }
    }
}