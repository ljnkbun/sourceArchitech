using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingComponentGroups
{
    public class GetSewingComponentGroupQuery : IRequest<Response<SewingComponentGroup>>
    {
        public int Id { get; set; }
    }
    public class GetSewingComponentGroupQueryHandler : IRequestHandler<GetSewingComponentGroupQuery, Response<SewingComponentGroup>>
    {
        private readonly ISewingComponentGroupRepository _repository;
        public GetSewingComponentGroupQueryHandler(ISewingComponentGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingComponentGroup>> Handle(GetSewingComponentGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingComponentGroup Not Found (Id:{query.Id}).");
            return new Response<SewingComponentGroup>(entity);
        }
    }
}
