using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Query.Locations
{
    public class GetLocationQuery : IRequest<Response<Location>>
    {
        public int Id { get; set; }
    }
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, Response<Location>>
    {
        private readonly ILocationRepository _repository;
        public GetLocationQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Location>> Handle(GetLocationQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Locations Not Found (Id:{query.Id}).");
            return new Response<Location>(entity);
        }
    }
}
