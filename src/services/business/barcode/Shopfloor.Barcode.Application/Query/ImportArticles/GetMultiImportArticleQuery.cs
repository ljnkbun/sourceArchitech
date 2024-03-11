using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ImportArticles
{
    public class GetMultiImportArticleQuery : IRequest<Response<List<ImportArticle>>>
    {
        public string Ids { get; set; }
    }
    public class GetMultiImportArticleQueryHandler : IRequestHandler<GetMultiImportArticleQuery, Response<List<ImportArticle>>>
    {
        private readonly IImportArticleRepository _repository;
        public GetMultiImportArticleQueryHandler(
            IImportArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<ImportArticle>>> Handle(GetMultiImportArticleQuery query, CancellationToken cancellationToken)
        {
            var ids = query.Ids.Split(",");
            var intIds = ids.Select(x => Convert.ToInt32(x)).ToArray();
            var entity = await _repository.GetImportArticleByIdsAsync(intIds);
            return entity == null
                ? new($"ImportArticle Not Found (Ids:{query.Ids}).")
                : new Response<List<ImportArticle>>(entity);
        }
    }
}
