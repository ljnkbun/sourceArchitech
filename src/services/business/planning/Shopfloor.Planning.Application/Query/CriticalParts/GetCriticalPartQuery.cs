using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.CriticalParts
{
    public class GetCriticalPartQuery : IRequest<Response<CriticalPart>>
    {
        public int Id { get; set; }
    }
    public class GetCriticalPartQueryHandler : IRequestHandler<GetCriticalPartQuery, Response<CriticalPart>>
    {
        private readonly ICriticalPartRepository _response;
        public GetCriticalPartQueryHandler(ICriticalPartRepository response)
        {
            _response = response;
        }
        public async Task<Response<CriticalPart>> Handle(GetCriticalPartQuery query, CancellationToken cancellationToken)
        {
            var entity = await _response.GetByIdAsync(query.Id);
            if (entity == null) return new($"CriticalPart Not Found (Id:{query.Id}).");
            return new Response<CriticalPart>(entity);
        }
    }
}
