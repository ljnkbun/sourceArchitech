using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.FactoryCapacitys
{
    public class GetFactoryCapacityQuery : IRequest<Response<FactoryCapacity>>
    {
        public int Id { get; set; }
    }
    public class GetFactoryCapacityQueryHandler : IRequestHandler<GetFactoryCapacityQuery, Response<FactoryCapacity>>
    {
        private readonly IFactoryCapacityRepository _repository;
        public GetFactoryCapacityQueryHandler(IFactoryCapacityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FactoryCapacity>> Handle(GetFactoryCapacityQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"FactoryCapacitys Not Found (Id:{query.Id}).");
            return new Response<FactoryCapacity>(entity);
        }
    }
}
