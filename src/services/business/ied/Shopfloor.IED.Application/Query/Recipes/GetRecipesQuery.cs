using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Recipes;
using Shopfloor.IED.Application.Parameters.Recipes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Recipes
{
    public class GetRecipesQuery : IRequest<PagedResponse<IReadOnlyList<RecipeModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRequestId { get; set; }

        public int? DyeingTBRVersionId { get; set; }

        public string RecipeNo { get; set; }

        public DateTime? JobDate { get; set; }

        public string TCFNO { get; set; }

        public string Style { get; set; }

        public string FabricCode { get; set; }

        public string FabricName { get; set; }

        public string Color { get; set; }

        public string LotNo { get; set; }

        public string RollKg { get; set; }

        public string Speed { get; set; }

        public string NozzleA { get; set; }

        public string NozzleB { get; set; }

        public string Method { get; set; }

        public string LAB { get; set; }

        public string InCharge { get; set; }

        public string Manager { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Recipes";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, PagedResponse<IReadOnlyList<RecipeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _repository;

        public GetRecipesQueryHandler(IMapper mapper,
            IRecipeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RecipeModel>>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RecipeParameter>(request);
            return await _repository.GetRecipePagedResponseAsync<RecipeParameter, RecipeModel>(validFilter);
        }
    }
}