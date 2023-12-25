using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class DeleteArticleBarcodeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteArticleBarcodeCommandHandler : IRequestHandler<DeleteArticleBarcodeCommand, Response<int>>
    {
        private readonly IArticleBarcodeRepository _repository;
        public DeleteArticleBarcodeCommandHandler(IArticleBarcodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteArticleBarcodeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ArticleBarcode Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
