using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.MaterialTypes;
using Shopfloor.Master.Application.Parameters.MaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.MaterialTypes
{
    public class GetMaterialTypesQuery : IRequest<PagedResponse<IReadOnlyList<MaterialTypeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"MaterialTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }

    public class GetMaterialTypesQueryHandler : IRequestHandler<GetMaterialTypesQuery, PagedResponse<IReadOnlyList<MaterialTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public GetMaterialTypesQueryHandler(IMapper mapper,
            IMaterialTypeRepository repository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<MaterialTypeModel>>> Handle(GetMaterialTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MaterialTypeParameter>(request);
            return await _repository.GetMaterialTypePagedResponseAsync<MaterialTypeParameter, MaterialTypeModel>(validFilter);
        }
    }
}