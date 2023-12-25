using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CategoryMapMaterialTypes
{
    public class GetCategoryMapMaterialTypeQuery : IRequest<Response<CategoryMapMaterialType>>
    {
        public int Id { get; set; }
    }
    public class GetCategoryMapMaterialTypeQueryHandler : IRequestHandler<GetCategoryMapMaterialTypeQuery, Response<CategoryMapMaterialType>>
    {
        private readonly ICategoryMapMaterialTypeRepository _repository;
        public GetCategoryMapMaterialTypeQueryHandler(ICategoryMapMaterialTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CategoryMapMaterialType>> Handle(GetCategoryMapMaterialTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"CategoryMapMaterialType Not Found (Id:{query.Id}).");
            return new Response<CategoryMapMaterialType>(entity);
        }
    }
}
