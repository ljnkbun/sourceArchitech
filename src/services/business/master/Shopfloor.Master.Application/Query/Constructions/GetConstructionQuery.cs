using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Constructions
{
    public class GetConstructionQuery : IRequest<Response<Construction>>
    {
        public int Id { get; set; }
    }
    public class GetConstructionQueryHandler : IRequestHandler<GetConstructionQuery, Response<Construction>>
    {
        private readonly IConstructionRepository _repository;
        public GetConstructionQueryHandler(IConstructionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Construction>> Handle(GetConstructionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Construction Not Found (Id:{query.Id}).");
            return new Response<Construction>(entity);
        }
    }
}
