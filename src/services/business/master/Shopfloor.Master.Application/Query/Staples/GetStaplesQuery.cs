using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Staples;
using Shopfloor.Master.Application.Parameters.SpinningMethods;
using Shopfloor.Master.Application.Parameters.Staples;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Staples
{
    public class GetStaplesQuery : IRequest<PagedResponse<IReadOnlyList<StapleModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Staples";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetStaplesQueryHandler : IRequestHandler<GetStaplesQuery, PagedResponse<IReadOnlyList<StapleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStapleRepository _repository;
        public GetStaplesQueryHandler(IMapper mapper,
            IStapleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StapleModel>>> Handle(GetStaplesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StapleParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(StapleParameter.Code), nameof(StapleParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<StapleParameter, StapleModel>(validFilter);
        }
    }
}
