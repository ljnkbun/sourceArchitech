using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RecipeCategories;
using Shopfloor.IED.Application.Parameters.RecipeCategories;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeCategories
{
    public class GetRecipeCategorysQuery : IRequest<PagedResponse<IReadOnlyList<RecipeCategoryModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"RecipeCategorys";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetRecipeCategorysQueryHandler : IRequestHandler<GetRecipeCategorysQuery, PagedResponse<IReadOnlyList<RecipeCategoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeCategoryRepository _repository;
        public GetRecipeCategorysQueryHandler(IMapper mapper,
            IRecipeCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RecipeCategoryModel>>> Handle(GetRecipeCategorysQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RecipeCategoryParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RecipeCategoryParameter, RecipeCategoryModel>(validFilter);
        }
    }
}
