using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.StripFactories
{
    public class GetStripFactoryQuery : IRequest<Response<StripFactory>>
    {
        public int Id { get; set; }
    }
    public class GetStripFactoryQueryHandler : IRequestHandler<GetStripFactoryQuery, Response<StripFactory>>
    {
        private readonly IStripFactoryRepository _repository;
        public GetStripFactoryQueryHandler(IStripFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<StripFactory>> Handle(GetStripFactoryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripFactorys Not Found (Id:{query.Id}).");
            return new Response<StripFactory>(entity);
        }
    }
}
