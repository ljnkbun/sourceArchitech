using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.CapacityColors
{
    public class GetCapacityColorQuery : IRequest<Response<CapacityColor>>
    {
        public int Id { get; set; }
    }
    public class GetCapacityColorQueryHandler : IRequestHandler<GetCapacityColorQuery, Response<CapacityColor>>
    {
        private readonly ICapacityColorRepository _repository;
        public GetCapacityColorQueryHandler(ICapacityColorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CapacityColor>> Handle(GetCapacityColorQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"CapacityColors Not Found (Id:{query.Id}).");
            return new Response<CapacityColor>(entity);
        }
    }
}
