using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Articles
{
    public class GetArticleByWFXIdQuery : IRequest<Response<Article>>
    {
        public int WFXArticleId { get; set; }
    }
    public class GetArticleByWFXIdQueryHandler : IRequestHandler<GetArticleByWFXIdQuery, Response<Article>>
    {
        private readonly IArticleRepository _repository;
        public GetArticleByWFXIdQueryHandler(IArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Article>> Handle(GetArticleByWFXIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetArticleByWFXIdAsync(query.WFXArticleId);
            if (entity == null) throw new ApiException($"Article Not Found (WFX Id:{query.WFXArticleId}).");
            return new Response<Article>(entity);
        }
    }
}
