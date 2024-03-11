using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ExportArticles
{
    public class GetExportArticleQuery : IRequest<Response<Domain.Entities.ExportArticle>>
    {
        public int Id { get; set; }
    }
    public class GetExportArticleEntityQueryHandler : IRequestHandler<GetExportArticleQuery, Response<Domain.Entities.ExportArticle>>
    {
        private readonly IExportArticleRepository _repository;
        public GetExportArticleEntityQueryHandler(
            IExportArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.ExportArticle>> Handle(GetExportArticleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportArticleByIdAsync(query.Id);
            return entity == null
                ? new($"Recipe Unit Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.ExportArticle>(entity);
        }
    }
}
