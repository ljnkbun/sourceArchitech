using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Zones
{
    public class GetZoneQuery : IRequest<Response<Zone>>
    {
        public int Id { get; set; }
    }
    public class GetZoneQueryHandler : IRequestHandler<GetZoneQuery, Response<Zone>>
    {
        private readonly IZoneRepository _repository;
        public GetZoneQueryHandler(IZoneRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Zone>> Handle(GetZoneQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Zone Not Found (Id:{query.Id}).");
            return new Response<Zone>(entity);
        }
    }
}
