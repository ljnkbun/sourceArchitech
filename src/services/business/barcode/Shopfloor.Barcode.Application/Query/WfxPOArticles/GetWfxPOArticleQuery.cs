using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxPOArticles
{
    public class GetWfxPOArticleQuery : IRequest<Response<Domain.Entities.WfxPOArticle>>
    {
        public int Id { get; set; }
    }
    public class GetWfxPOArticleQueryHandler : IRequestHandler<GetWfxPOArticleQuery, Response<Domain.Entities.WfxPOArticle>>
    {
        private readonly IWfxPOArticleRepository _repository;
        public GetWfxPOArticleQueryHandler(
            IWfxPOArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.WfxPOArticle>> Handle(GetWfxPOArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? new($"WfxPOArticle Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.WfxPOArticle>(entity);
        }
    }
}
