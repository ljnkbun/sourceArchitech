using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.MaterialTypeMapProductGroups
{
    public class GetMaterialTypeMapProductGroupQuery : IRequest<Response<MaterialTypeMapProductGroup>>
    {
        public int Id { get; set; }
    }
    public class GetMaterialTypeMapProductGroupQueryHandler : IRequestHandler<GetMaterialTypeMapProductGroupQuery, Response<MaterialTypeMapProductGroup>>
    {
        private readonly IMaterialTypeMapProductGroupRepository _repository;
        public GetMaterialTypeMapProductGroupQueryHandler(IMaterialTypeMapProductGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<MaterialTypeMapProductGroup>> Handle(GetMaterialTypeMapProductGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"MaterialTypeMapProductGroup Not Found (Id:{query.Id}).");
            return new Response<MaterialTypeMapProductGroup>(entity);
        }
    }
}
