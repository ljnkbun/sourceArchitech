using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.FabricContents
{
    public class GetFabricContentQuery : IRequest<Response<FabricContent>>
    {
        public int Id { get; set; }
    }
    public class GetFabricContentQueryHandler : IRequestHandler<GetFabricContentQuery, Response<FabricContent>>
    {
        private readonly IFabricContentRepository _repository;
        public GetFabricContentQueryHandler(IFabricContentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FabricContent>> Handle(GetFabricContentQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"FabricContent Not Found (Id:{query.Id}).");
            return new Response<FabricContent>(entity);
        }
    }
}
