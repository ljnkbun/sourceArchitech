using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RecipeUnits;
using Shopfloor.IED.Application.Parameters.RecipeUnits;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeUnits
{
    public class GetRecipeUnitsQuery : IRequest<PagedResponse<IReadOnlyList<RecipeUnitModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"RecipeUnits";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetRecipeUnitsQueryHandler : IRequestHandler<GetRecipeUnitsQuery, PagedResponse<IReadOnlyList<RecipeUnitModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeUnitRepository _repository;
        public GetRecipeUnitsQueryHandler(IMapper mapper,
            IRecipeUnitRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RecipeUnitModel>>> Handle(GetRecipeUnitsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RecipeUnitParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RecipeUnitParameter, RecipeUnitModel>(validFilter);
        }
    }
}
