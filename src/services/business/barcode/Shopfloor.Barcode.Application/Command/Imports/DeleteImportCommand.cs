using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class DeleteImportCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteImportCommandHandler : IRequestHandler<DeleteImportCommand, Response<int>>
    {
        private readonly IImportRepository _repository;
        public DeleteImportCommandHandler(IImportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteImportCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetImportByIdAsync(command.Id);
            if (entity == null) return new($"Import Not Found (Id:{command.Id}).");
            var articleBarcodes = entity.ImportArticles.SelectMany(x => x.ImportDetails).Select(y => y.ArticleBarcode);
            await _repository.DeleteImportAsync(entity, articleBarcodes);
            return new Response<int>(entity.Id);
        }
    }
}
