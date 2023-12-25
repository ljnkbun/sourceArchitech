using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Query.BarcodeLocations
{
    public class GetBarcodeLocationQuery : IRequest<Response<BarcodeLocation>>
    {
        public int Id { get; set; }
    }
    public class GetBarcodeLocationQueryHandler : IRequestHandler<GetBarcodeLocationQuery, Response<BarcodeLocation>>
    {
        private readonly IBarcodeLocationRepository _repository;
        public GetBarcodeLocationQueryHandler(IBarcodeLocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<BarcodeLocation>> Handle(GetBarcodeLocationQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"BarcodeLocations Not Found (Id:{query.Id}).");
            return new Response<BarcodeLocation>(entity);
        }
    }
}
