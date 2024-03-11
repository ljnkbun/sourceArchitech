using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportArticles
{
    public class DeleteImportArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteImportArticleCommandHandler : IRequestHandler<DeleteImportArticleCommand, Response<int>>
    {
        private readonly IImportArticleRepository _repository;
        public DeleteImportArticleCommandHandler(IImportArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteImportArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetImportArticleByIdAsync(command.Id);
            if (entity == null) return new($"ImportArticle Not Found (Id:{command.Id}).");
            var articleBarcodes = entity.ImportDetails.Select(y => y.ArticleBarcode);
            await _repository.DeleteImportArticleAsync(entity, articleBarcodes);
            return new Response<int>(entity.Id);
        }
    }
}
