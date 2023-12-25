using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Factories
{
    public class GetFactoryQuery : IRequest<Response<Factory>>
    {
        public int Id { get; set; }
    }
    public class GetFactoryQueryHandler : IRequestHandler<GetFactoryQuery, Response<Factory>>
    {
        private readonly IFactoryRepository _repository;
        public GetFactoryQueryHandler(IFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Factory>> Handle(GetFactoryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Factory Not Found (Id: {query.Id}).");
            return new Response<Factory>(entity);
        }
    }
}
