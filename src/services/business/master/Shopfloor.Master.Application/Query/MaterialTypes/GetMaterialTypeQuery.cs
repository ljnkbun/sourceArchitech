using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.MaterialTypes
{
    public class GetMaterialTypeQuery : IRequest<Response<MaterialType>>
    {
        public int Id { get; set; }
    }
    public class GetMaterialTypeQueryHandler : IRequestHandler<GetMaterialTypeQuery, Response<MaterialType>>
    {
        private readonly IMaterialTypeRepository _repository;
        public GetMaterialTypeQueryHandler(IMaterialTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<MaterialType>> Handle(GetMaterialTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"MaterialType Not Found (Id: {query.Id}).");
            return new Response<MaterialType>(entity);
        }
    }
}
