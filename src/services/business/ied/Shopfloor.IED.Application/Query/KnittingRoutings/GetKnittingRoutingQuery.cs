using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingRoutings
{
    public class GetKnittingRoutingQuery : IRequest<Response<KnittingRouting>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingRoutingQueryHandler : IRequestHandler<GetKnittingRoutingQuery, Response<KnittingRouting>>
    {
        private readonly IKnittingRoutingRepository _repository;
        public GetKnittingRoutingQueryHandler(IKnittingRoutingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingRouting>> Handle(GetKnittingRoutingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingRouting Not Found (Id:{query.Id}).");
            return new Response<KnittingRouting>(entity);
        }
    }
}
