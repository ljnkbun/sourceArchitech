using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RecipeTasks;
using Shopfloor.IED.Application.Parameters.RecipeTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RecipeTasks
{
    public class GetRecipeTasksQuery : IRequest<PagedResponse<IReadOnlyList<RecipeTaskModel>>>
    {
        public int? RecipeId { get; set; }

        public int? DyeingProcessId { get; set; }

        public string DyeingProcessName { get; set; }

        public int? DyeingOperationId { get; set; }

        public string? DyeingOperationName { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal? Time { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? Ratio { get; set; }

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