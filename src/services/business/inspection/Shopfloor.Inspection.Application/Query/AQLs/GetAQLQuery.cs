using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.AQLs
{
    public class GetAQLQuery : IRequest<Response<AQL>>
    {
        public int Id { get; set; }
    }
    public class GetAQLQueryHandler : IRequestHandler<GetAQLQuery, Response<AQL>>
    {
        private readonly IAQLRepository _repository;
        public GetAQLQueryHandler(IAQLRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<AQL>> Handle(GetAQLQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"AQLs Not Found (Id:{query.Id}).");
            return new Response<AQL>(entity);
        }
    }
}
