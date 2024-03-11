using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.MaterialRequests
{
    public class GetMaterialRequestQuery : IRequest<Response<Domain.Entities.MaterialRequest>>
    {
        public int Id { get; set; }
    }

    public class GetMaterialRequestQueryHandler : IRequestHandler<GetMaterialRequestQuery, Response<Domain.Entities.MaterialRequest>>
    {
        private readonly IMaterialRequestRepository _repository;

        public GetMaterialRequestQueryHandler(IMaterialRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.MaterialRequest>> Handle(GetMaterialRequestQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"MaterialRequest Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.MaterialRequest>(entity);
        }
    }
}