using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.CategoryMapMaterialTypes;
using Shopfloor.Master.Application.Parameters.CategoryMapMaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CategoryMapMaterialTypes
{
    public class GetCategoryMapMaterialTypesQuery : IRequest<PagedResponse<IReadOnlyList<CategoryMapMaterialTypeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public int? CategoryId { get; set; }
        public int? MaterialTypeId { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"CategoryMapMaterialTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCategoryMapMaterialTypesQueryHandler : IRequestHandler<GetCategoryMapMaterialTypesQuery, PagedResponse<IReadOnlyList<CategoryMapMaterialTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryMapMaterialTypeRepository _repository;
        public GetCategoryMapMaterialTypesQueryHandler(IMapper mapper,
            ICategoryMapMaterialTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CategoryMapMaterialTypeModel>>> Handle(GetCategoryMapMaterialTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CategoryMapMaterialTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CategoryMapMaterialTypeParameter.CategoryId), nameof(CategoryMapMaterialTypeParameter.MaterialTypeId) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CategoryMapMaterialTypeParameter, CategoryMapMaterialTypeModel>(validFilter);
        }
    }
}
