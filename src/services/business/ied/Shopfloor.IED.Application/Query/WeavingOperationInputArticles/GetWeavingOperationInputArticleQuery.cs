using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingOperationInputArticles
{
    public class GetWeavingOperationInputArticleQuery : IRequest<Response<WeavingOperationInputArticle>>
    {
        public int Id { get; set; }
    }

    public class GetWeavingOperationInputArticleQueryHandler : IRequestHandler<GetWeavingOperationInputArticleQuery, Response<WeavingOperationInputArticle>>
    {
        private readonly IWeavingOperationInputArticleRepository _repository;

        public GetWeavingOperationInputArticleQueryHandler(IWeavingOperationInputArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WeavingOperationInputArticle>> Handle(GetWeavingOperationInputArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingOperationInputArticle Not Found (Id:{query.Id}).");
            return new Response<WeavingOperationInputArticle>(entity);
        }
    }
}