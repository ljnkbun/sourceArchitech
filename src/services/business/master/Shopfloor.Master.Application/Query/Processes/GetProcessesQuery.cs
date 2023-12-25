using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Processes;
using Shopfloor.Master.Application.Parameters.SpinningMethods;
using Shopfloor.Master.Application.Parameters.Processes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Processes
{
    public class GetProcessesQuery : IRequest<PagedResponse<IReadOnlyList<ProcessModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Processes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProcessesQueryHandler : IRequestHandler<GetProcessesQuery, PagedResponse<IReadOnlyList<ProcessModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _repository;
        public GetProcessesQueryHandler(IMapper mapper,
            IProcessRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProcessModel>>> Handle(GetProcessesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProcessParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ProcessParameter.Code), nameof(ProcessParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ProcessParameter, ProcessModel>(validFilter);
        }
    }
}
