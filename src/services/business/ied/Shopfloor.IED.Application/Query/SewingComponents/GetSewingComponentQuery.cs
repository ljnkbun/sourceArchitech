using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingComponents
{
    public class GetSewingComponentQuery : IRequest<Response<SewingComponent>>
    {
        public int Id { get; set; }
    }
    public class GetSewingComponentQueryHandler : IRequestHandler<GetSewingComponentQuery, Response<SewingComponent>>
    {
        private readonly ISewingComponentRepository _repository;
        public GetSewingComponentQueryHandler(ISewingComponentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingComponent>> Handle(GetSewingComponentQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingComponent Not Found (Id:{query.Id}).");
            return new Response<SewingComponent>(entity);
        }
    }
}
