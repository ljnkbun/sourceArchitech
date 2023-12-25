using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RecipeTasks;
using Shopfloor.IED.Application.Parameters.RecipeTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeTasks
{
    public class GetRecipeTasksQuery : IRequest<PagedResponse<IReadOnlyList<RecipeTaskModel>>>, ICacheableMediatrQuery
    {
        public int? RecipeId { get; set; }

        public string DyeingOpreation { get; set; }

        public string MachineType { get; set; }

        public int? Minutes { get; set; }

        public decimal? Temperature { get; set; }

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
        public string CacheKey => $"RecipeTasks";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetRecipeTasksQueryHandler : IRequestHandler<GetRecipeTasksQuery, PagedResponse<IReadOnlyList<RecipeTaskModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeTaskRepository _repository;

        public GetRecipeTasksQueryHandler(IMapper mapper,
            IRecipeTaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RecipeTaskModel>>> Handle(GetRecipeTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RecipeTaskParameter>(request);
            return await _repository.GetRecipeTaskPagedResponseAsync<RecipeTaskParameter, RecipeTaskModel>(validFilter);
        }
    }
}