using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingYarns
{
    public class GetWeavingYarnQuery : IRequest<Response<WeavingYarn>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingYarnQueryHandler : IRequestHandler<GetWeavingYarnQuery, Response<WeavingYarn>>
    {
        private readonly IWeavingYarnRepository _repository;
        public GetWeavingYarnQueryHandler(IWeavingYarnRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingYarn>> Handle(GetWeavingYarnQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"WeavingYarn Not Found (Id:{query.Id}).");
            return new Response<WeavingYarn>(entity);
        }
    }
}
