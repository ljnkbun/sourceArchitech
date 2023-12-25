using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.FabricWidths
{
    public class GetFabricWidthQuery : IRequest<Response<FabricWidth>>
    {
        public int Id { get; set; }
    }
    public class GetFabricWidthQueryHandler : IRequestHandler<GetFabricWidthQuery, Response<FabricWidth>>
    {
        private readonly IFabricWidthRepository _repository;
        public GetFabricWidthQueryHandler(IFabricWidthRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FabricWidth>> Handle(GetFabricWidthQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"FabricWidth Not Found (Id: {query.Id}).");
            return new Response<FabricWidth>(entity);
        }
    }
}
