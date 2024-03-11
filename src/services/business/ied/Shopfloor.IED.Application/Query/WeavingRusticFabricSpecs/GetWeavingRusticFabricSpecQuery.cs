using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRusticFabricSpecs
{
    public class GetWeavingRusticFabricSpecQuery : IRequest<Response<WeavingRusticFabricSpec>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingRusticFabricSpecQueryHandler : IRequestHandler<GetWeavingRusticFabricSpecQuery, Response<WeavingRusticFabricSpec>>
    {
        private readonly IWeavingRusticFabricSpecRepository _repository;
        public GetWeavingRusticFabricSpecQueryHandler(IWeavingRusticFabricSpecRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingRusticFabricSpec>> Handle(GetWeavingRusticFabricSpecQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingRusticFabricSpec Not Found (Id:{query.Id}).");
            return new Response<WeavingRusticFabricSpec>(entity);
        }
    }
}
