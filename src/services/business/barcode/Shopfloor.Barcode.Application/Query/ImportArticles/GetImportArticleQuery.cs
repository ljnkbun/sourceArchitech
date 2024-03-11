using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ImportArticles
{
    public class GetImportArticleQuery : IRequest<Response<Domain.Entities.ImportArticle>>
    {
        public int Id { get; set; }
    }
    public class GetImportArticleQueryHandler : IRequestHandler<GetImportArticleQuery, Response<Domain.Entities.ImportArticle>>
    {
        private readonly IImportArticleRepository _repository;
        public GetImportArticleQueryHandler(
            IImportArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.ImportArticle>> Handle(GetImportArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetImportArticleByIdAsync(query.Id);
            return entity == null
                ? new($"ImportArticle Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.ImportArticle>(entity);
        }
    }
}
