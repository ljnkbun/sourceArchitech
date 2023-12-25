using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingTasks;
using Shopfloor.IED.Application.Parameters.SewingTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingTasks
{
    public class GetSewingTasksQuery : IRequest<PagedResponse<IReadOnlyList<SewingTaskModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal? TotalTMU { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingTasks";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingTasksQueryHandler : IRequestHandler<GetSewingTasksQuery, PagedResponse<IReadOnlyList<SewingTaskModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingTaskRepository _repository;
        public GetSewingTasksQueryHandler(IMapper mapper,
            ISewingTaskRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingTaskModel>>> Handle(GetSewingTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingTaskParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingTaskParameter.Code), nameof(SewingTaskParameter.Name), nameof(SewingTaskParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingTaskParameter, SewingTaskModel>(validFilter);
        }
    }
}
