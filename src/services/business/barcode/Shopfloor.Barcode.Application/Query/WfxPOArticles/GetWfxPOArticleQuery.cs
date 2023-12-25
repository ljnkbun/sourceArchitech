using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxPOArticles
{
    public class GetWfxPOArticleQuery : IRequest<Response<WfxPOArticle>>
    {
        public int Id { get; set; }
    }
    public class GetWfxPOArticleEntityQueryHandler : IRequestHandler<GetWfxPOArticleQuery, Response<WfxPOArticle>>
    {
        private readonly IWfxPOArticleRepository _repository;
        public GetWfxPOArticleEntityQueryHandler(
            IWfxPOArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WfxPOArticle>> Handle(GetWfxPOArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? throw new ApiException($"Recipe Unit Not Found (Id:{query.Id}).")
                : new Response<WfxPOArticle>(entity);
        }
    }
}
