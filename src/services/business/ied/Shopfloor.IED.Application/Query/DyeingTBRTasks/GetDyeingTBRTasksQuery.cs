using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRTasks;
using Shopfloor.IED.Application.Parameters.DyeingTBRTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRTasks
{
    public class GetDyeingTBRTasksQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRTaskModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRecipeId { get; set; }
        public int? DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int? DyeingOperationId { get; set; }
        public string DyeingOperationName { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public decimal? Temperature { get; set; }
        public int? Minute { get; set; }

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
        public string CacheKey => $"DyeingTBRTasks";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRTasksQueryHandler : IRequestHandler<GetDyeingTBRTasksQuery, PagedResponse<IReadOnlyList<DyeingTBRTaskModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRTaskRepository _repository;

        public GetDyeingTBRTasksQueryHandler(IMapper mapper,
            IDyeingTBRTaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRTaskModel>>> Handle(GetDyeingTBRTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRTaskParameter>(request);
            return await _repository.GetTaskPagedResponseAsync<DyeingTBRTaskParameter, DyeingTBRTaskModel>(validFilter);
        }
    }
}