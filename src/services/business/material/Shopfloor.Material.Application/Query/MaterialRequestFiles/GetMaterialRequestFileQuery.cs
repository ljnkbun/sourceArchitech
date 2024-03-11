using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.MaterialRequestFiles
{
    public class GetMaterialRequestFileQuery : IRequest<Response<Domain.Entities.MaterialRequestFile>>
    {
        public int Id { get; set; }
    }

    public class GetMaterialRequestFileQueryHandler : IRequestHandler<GetMaterialRequestFileQuery, Response<Domain.Entities.MaterialRequestFile>>
    {
        private readonly IMaterialRequestFileRepository _repository;

        public GetMaterialRequestFileQueryHandler(IMaterialRequestFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.MaterialRequestFile>> Handle(GetMaterialRequestFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"MaterialRequestFile Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.MaterialRequestFile>(entity);
        }
    }
}