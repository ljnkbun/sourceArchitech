using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingRoutings
{
    public class GetSewingRoutingQuery : IRequest<Response<SewingRouting>>
    {
        public int Id { get; set; }
    }
    public class GetSewingRoutingQueryHandler : IRequestHandler<GetSewingRoutingQuery, Response<SewingRouting>>
    {
        private readonly ISewingRoutingRepository _RoutingRepository;

        public GetSewingRoutingQueryHandler(ISewingRoutingRepository RoutingRepository)
        {
            _RoutingRepository = RoutingRepository;
        }
        public async Task<Response<SewingRouting>> Handle(GetSewingRoutingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _RoutingRepository.GetSewingRoutingByIdAsync(query.Id);
            if (entity == null) return new($"SewingRouting Not Found (Id:{query.Id}).");
            return new Response<SewingRouting>(entity);
        }
    }
}
