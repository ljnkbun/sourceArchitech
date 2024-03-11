using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.PORs
{
    public class GetPORQuery : IRequest<Response<POR>>
    {
        public int Id { get; set; }
    }
    public class GetPORQueryHandler : IRequestHandler<GetPORQuery, Response<POR>>
    {
        private readonly IPORRepository _response;
        public GetPORQueryHandler(IPORRepository response)
        {
            _response = response;
        }
        public async Task<Response<POR>> Handle(GetPORQuery query, CancellationToken cancellationToken)
        {
            var entity = await _response.GetByIdAsync(query.Id);
            if (entity == null) return new($"POR Not Found (Id:{query.Id}).");
            return new Response<POR>(entity);
        }
    }
}
