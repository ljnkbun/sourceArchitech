using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.SpinningProcesses;
using Shopfloor.Master.Application.Parameters.SpinningMethods;
using Shopfloor.Master.Application.Parameters.SpinningProcesses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SpinningProcesses
{
    public class GetSpinningProcessesQuery : IRequest<PagedResponse<IReadOnlyList<SpinningProcessModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"SpinningProcess";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSpinningProcessesQueryHandler : IRequestHandler<GetSpinningProcessesQuery, PagedResponse<IReadOnlyList<SpinningProcessModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISpinningProcessRepository _repository;
        public GetSpinningProcessesQueryHandler(IMapper mapper,
            ISpinningProcessRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SpinningProcessModel>>> Handle(GetSpinningProcessesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SpinningProcessParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SpinningProcessParameter.Code), nameof(SpinningProcessParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SpinningProcessParameter, SpinningProcessModel>(validFilter);
        }
    }
}
