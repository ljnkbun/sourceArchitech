using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRoutings
{
    public class GetWeavingRoutingQuery : IRequest<Response<WeavingRouting>>
    {
        public int Id { get; set; }
    }

    public class GetWeavingRoutingQueryHandler : IRequestHandler<GetWeavingRoutingQuery, Response<WeavingRouting>>
    {
        private readonly IWeavingRoutingRepository _repository;

        public GetWeavingRoutingQueryHandler(IWeavingRoutingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WeavingRouting>> Handle(GetWeavingRoutingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"WeavingRouting Not Found (Id:{query.Id}).");
            return new Response<WeavingRouting>(entity);
        }
    }
}