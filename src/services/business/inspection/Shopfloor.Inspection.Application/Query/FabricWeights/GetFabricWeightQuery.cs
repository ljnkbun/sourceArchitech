using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.FabricWeights
{
    public class GetFabricWeightQuery : IRequest<Response<FabricWeight>>
    {
        public int Id { get; set; }
    }
    public class GetFabricWeightQueryHandler : IRequestHandler<GetFabricWeightQuery, Response<FabricWeight>>
    {
        private readonly IFabricWeightRepository _repository;
        public GetFabricWeightQueryHandler(IFabricWeightRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FabricWeight>> Handle(GetFabricWeightQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"FabricWeights Not Found (Id:{query.Id}).");
            return new Response<FabricWeight>(entity);
        }
    }
}
