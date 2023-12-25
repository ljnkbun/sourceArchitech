using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RecipeChemicals;
using Shopfloor.IED.Application.Parameters.RecipeChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeChemicals
{
    public class GetRecipeChemicalsQuery : IRequest<PagedResponse<IReadOnlyList<RecipeChemicalModel>>>, ICacheableMediatrQuery
    {
        public int? RecipeTaskId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string Unit { get; set; }

        public decimal? Value { get; set; }

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
        public string CacheKey => $"RecipeChemicals";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetRecipeChemicalsQueryHandler : IRequestHandler<GetRecipeChemicalsQuery, PagedResponse<IReadOnlyList<RecipeChemicalModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeChemicalRepository _repository;

        public GetRecipeChemicalsQueryHandler(IMapper mapper,
            IRecipeChemicalRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RecipeChemicalModel>>> Handle(GetRecipeChemicalsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RecipeChemicalParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RecipeChemicalParameter, RecipeChemicalModel>(validFilter);
        }
    }
}