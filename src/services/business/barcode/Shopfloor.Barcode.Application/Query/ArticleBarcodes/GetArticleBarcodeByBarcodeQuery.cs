using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodeByBarcodeQuery : IRequest<Response<ArticleBarcode>>
    {
        public string Barcode { get; set; }
    }
    public class GetArticleBarcodeByBarcodeQueryHandler : IRequestHandler<GetArticleBarcodeByBarcodeQuery, Response<ArticleBarcode>>
    {
        private readonly IArticleBarcodeRepository _repository;
        public GetArticleBarcodeByBarcodeQueryHandler(IArticleBarcodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ArticleBarcode>> Handle(GetArticleBarcodeByBarcodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByBarcodeAsync(query.Barcode);
            if (entity == null) throw new ApiException($"ArticleBarcodes Not Found (Barcode:{query.Barcode}).");
            return new Response<ArticleBarcode>(entity);
        }
    }
}
