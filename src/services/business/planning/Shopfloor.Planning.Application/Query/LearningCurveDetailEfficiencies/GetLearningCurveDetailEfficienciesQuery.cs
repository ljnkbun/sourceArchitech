using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Application.Parameters.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.LearningCurveDetailEfficiencies
{
    public class GetLearningCurveDetailEfficienciesQuery : IRequest<PagedResponse<IReadOnlyList<LearningCurveDetailEfficiencyModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public int? Days { get; set; }
        public decimal? EfficiencyValue { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"LearningCurveDetailEfficiencies";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetLearningCurveDetailEfficienciesQueryHandler : IRequestHandler<GetLearningCurveDetailEfficienciesQuery, PagedResponse<IReadOnlyList<LearningCurveDetailEfficiencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILearningCurveDetailEfficiencyRepository _repository;
        public GetLearningCurveDetailEfficienciesQueryHandler(IMapper mapper,
            ILearningCurveDetailEfficiencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LearningCurveDetailEfficiencyModel>>> Handle(GetLearningCurveDetailEfficienciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LearningCurveDetailEfficiencyParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(LearningCurveDetailEfficiencyParameter.Code), nameof(LearningCurveDetailEfficiencyParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<LearningCurveDetailEfficiencyParameter, LearningCurveDetailEfficiencyModel>(validFilter);
        }
    }
}
