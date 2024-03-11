using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class ScanArticleBarcodeQuery : IRequest<Response<ICollection<ArticleBarcode>>>
    {
        public string Barcodes { get; set; }
    }
    public class ScanArticleBarcodeQueryHandler : IRequestHandler<ScanArticleBarcodeQuery, Response<ICollection<ArticleBarcode>>>
    {
        private readonly IArticleBarcodeRepository _repository;
        public ScanArticleBarcodeQueryHandler(
            IArticleBarcodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<ICollection<ArticleBarcode>>> Handle(ScanArticleBarcodeQuery request, CancellationToken cancellationToken)
        {
            var barcodes = request.Barcodes.Split(',').Select(x => x.Trim());
            var entities = await _repository.GetAllByBarcodesAsync(barcodes.ToArray());
            if (entities == null || !entities.Any()) return new("Barcode not found.");

            return new Response<ICollection<ArticleBarcode>>(entities);
        }
    }
}
