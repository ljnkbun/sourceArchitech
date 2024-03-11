using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRappos
{
    public class GetWeavingRappoQuery : IRequest<Response<WeavingRappo>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingRappoQueryHandler : IRequestHandler<GetWeavingRappoQuery, Response<WeavingRappo>>
    {
        private readonly IWeavingRappoRepository _repository;
        public GetWeavingRappoQueryHandler(IWeavingRappoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingRappo>> Handle(GetWeavingRappoQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWeavingRappoByIdAsync(query.Id);
            if (entity == null) return new($"WeavingRappo Not Found (Id:{query.Id}).");
            return new Response<WeavingRappo>(entity);
        }
    }
}
