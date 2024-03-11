using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.ZoneTypes
{
    public class GetZoneTypeQuery : IRequest<Response<ZoneType>>
    {
        public int Id { get; set; }
    }
    public class GetZoneTypeQueryHandler : IRequestHandler<GetZoneTypeQuery, Response<ZoneType>>
    {
        private readonly IZoneTypeRepository _repository;
        public GetZoneTypeQueryHandler(IZoneTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ZoneType>> Handle(GetZoneTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"ZoneTypes Not Found (Id:{query.Id}).");
            return new Response<ZoneType>(entity);
        }
    }
}
