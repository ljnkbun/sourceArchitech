using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodeQuery : IRequest<Response<ArticleBarcode>>
    {
        public int Id { get; set; }
    }
    public class GetArticleBarcodeQueryHandler : IRequestHandler<GetArticleBarcodeQuery, Response<ArticleBarcode>>
    {
        private readonly IArticleBarcodeRepository _repository;
        public GetArticleBarcodeQueryHandler(IArticleBarcodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ArticleBarcode>> Handle(GetArticleBarcodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"ArticleBarcodes Not Found (Id:{query.Id}).");
            return new Response<ArticleBarcode>(entity);
        }
    }
}
