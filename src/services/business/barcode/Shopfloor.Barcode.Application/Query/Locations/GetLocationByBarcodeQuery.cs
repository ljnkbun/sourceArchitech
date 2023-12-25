using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Locations
{
    public class GetLocationByBarcodeQuery : IRequest<Response<Location>>
    {
        public string Barcode { get; set; }
    }
    public class GetLocationByBarcodeQueryHandler : IRequestHandler<GetLocationByBarcodeQuery, Response<Location>>
    {
        private readonly ILocationRepository _repository;
        public GetLocationByBarcodeQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Location>> Handle(GetLocationByBarcodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByBarcodeAsync(query.Barcode);
            if (entity == null) throw new ApiException($"Locations Not Found (Barcode:{query.Barcode}).");
            return new Response<Location>(entity);
        }
    }
}
