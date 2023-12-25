using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingDetailStructures
{
    public class GetWeavingDetailStructureQuery : IRequest<Response<WeavingDetailStructure>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingDetailStructureQueryHandler : IRequestHandler<GetWeavingDetailStructureQuery, Response<WeavingDetailStructure>>
    {
        private readonly IWeavingDetailStructureRepository _repository;
        public GetWeavingDetailStructureQueryHandler(IWeavingDetailStructureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingDetailStructure>> Handle(GetWeavingDetailStructureQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"WeavingDetailStructure Not Found (Id:{query.Id}).");
            return new Response<WeavingDetailStructure>(entity);
        }
    }
}
