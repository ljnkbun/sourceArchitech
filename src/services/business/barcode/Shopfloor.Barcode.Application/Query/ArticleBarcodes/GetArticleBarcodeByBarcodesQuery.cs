using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodeByBarcodesQuery : IRequest<Response<ICollection<ArticleBarcode>>>
    {
        public string Barcodes { get; set; }
    }
    public class GetArticleBarcodeByBarcodesQueryHandler : IRequestHandler<GetArticleBarcodeByBarcodesQuery, Response<ICollection<ArticleBarcode>>>
    {
        private readonly IArticleBarcodeRepository _repository;
        public GetArticleBarcodeByBarcodesQueryHandler(IArticleBarcodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<ICollection<ArticleBarcode>>> Handle(GetArticleBarcodeByBarcodesQuery query, CancellationToken cancellationToken)
        {
            var barcodes = query.Barcodes.Split(',').Select(x => x.Trim());
            var entities = await _repository.GetAllByBarcodesAsync(barcodes.ToArray());
            if (entities == null || !entities.Any()) return new($"ArticleBarcodes Not Found.");
            return new Response<ICollection<ArticleBarcode>>(entities);
        }
    }
}
