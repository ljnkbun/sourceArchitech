using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.AQLVersions
{
    public class GetAQLVersionQuery : IRequest<Response<AQLVersion>>
    {
        public int Id { get; set; }
    }
    public class GetAQLVersionQueryHandler : IRequestHandler<GetAQLVersionQuery, Response<AQLVersion>>
    {
        private readonly IAQLVersionRepository _repository;
        public GetAQLVersionQueryHandler(IAQLVersionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<AQLVersion>> Handle(GetAQLVersionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAQLVersionByIdAsync(query.Id);
            if (entity == null) return new ($"AQLVersions Not Found (Id:{query.Id}).");
            return new Response<AQLVersion>(entity);
        }
    }
}
