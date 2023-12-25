using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Articles
{
    public class GetArticleQuery : IRequest<Response<Article>>
    {
        public int Id { get; set; }
    }
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, Response<Article>>
    {
        private readonly IArticleRepository _repository;
        public GetArticleQueryHandler(IArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Article>> Handle(GetArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetArticleByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Article Not Found (Id:{query.Id}).");
            return new Response<Article>(entity);
        }
    }
}
