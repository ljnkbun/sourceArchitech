using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRappoMatrics
{
    public class GetWeavingRappoMatricQuery : IRequest<Response<WeavingRappoMatric>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingRappoMatricQueryHandler : IRequestHandler<GetWeavingRappoMatricQuery, Response<WeavingRappoMatric>>
    {
        private readonly IWeavingRappoMatricRepository _repository;
        public GetWeavingRappoMatricQueryHandler(IWeavingRappoMatricRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingRappoMatric>> Handle(GetWeavingRappoMatricQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingRappoMatric Not Found (Id:{query.Id}).");
            return new Response<WeavingRappoMatric>(entity);
        }
    }
}
