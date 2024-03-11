using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ShipmentTerms
{
    public class GetShipmentTermQuery : IRequest<Response<ShipmentTerm>>
    {
        public int Id { get; set; }
    }
    public class GetShipmentTermQueryHandler : IRequestHandler<GetShipmentTermQuery, Response<ShipmentTerm>>
    {
        private readonly IShipmentTermRepository _repository;
        public GetShipmentTermQueryHandler(IShipmentTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ShipmentTerm>> Handle(GetShipmentTermQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ShipmentTerm Not Found (Id:{query.Id}).");
            return new Response<ShipmentTerm>(entity);
        }
    }
}
