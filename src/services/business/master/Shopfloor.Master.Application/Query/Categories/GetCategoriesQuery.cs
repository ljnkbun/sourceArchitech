using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Categories;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.Categories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Categories
{
    public class GetCategoriesQuery : IRequest<PagedResponse<IReadOnlyList<CategoryModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Categories";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCategorysQueryHandler : IRequestHandler<GetCategoriesQuery, PagedResponse<IReadOnlyList<CategoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        public GetCategorysQueryHandler(IMapper mapper,
            ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CategoryModel>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CategoryParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CategoryParameter.Code), nameof(CategoryParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CategoryParameter, CategoryModel>(validFilter);
        }
    }
}
