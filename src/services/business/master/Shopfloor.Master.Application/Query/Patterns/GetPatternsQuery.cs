using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Patterns;
using Shopfloor.Master.Application.Parameters.Micronaires;
using Shopfloor.Master.Application.Parameters.Patterns;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Patterns
{
    public class GetPatternsQuery : IRequest<PagedResponse<IReadOnlyList<PatternModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Patterns";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPatternsQueryHandler : IRequestHandler<GetPatternsQuery, PagedResponse<IReadOnlyList<PatternModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPatternRepository _repository;
        public GetPatternsQueryHandler(IMapper mapper,
            IPatternRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PatternModel>>> Handle(GetPatternsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PatternParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(PatternParameter.Code), nameof(PatternParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<PatternParameter, PatternModel>(validFilter);
        }
    }
}
