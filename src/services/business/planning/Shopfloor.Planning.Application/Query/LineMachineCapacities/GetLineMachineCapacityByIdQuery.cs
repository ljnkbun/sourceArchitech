using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.LineMachineCapacitys
{
    public class GetLineMachineCapacityByIdQuery : IRequest<Response<LineMachineCapacity>>
    {
        public int Id { get; set; }
    }
    public class GetLineMachineCapacityQueryHandler : IRequestHandler<GetLineMachineCapacityByIdQuery, Response<LineMachineCapacity>>
    {
        private readonly ILineMachineCapacityRepository _repository;
        public GetLineMachineCapacityQueryHandler(ILineMachineCapacityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<LineMachineCapacity>> Handle(GetLineMachineCapacityByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"LineMachineCapacitys Not Found (Id:{query.Id}).");
            return new Response<LineMachineCapacity>(entity);
        }
    }
}
