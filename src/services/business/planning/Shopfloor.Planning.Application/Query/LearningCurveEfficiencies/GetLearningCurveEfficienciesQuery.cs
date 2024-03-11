using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.LearningCurveEfficiencies;
using Shopfloor.Planning.Application.Parameters.LearningCurveEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.LearningCurveEfficiencies
{
    public class GetLearningCurveEfficienciesQuery : IRequest<PagedResponse<IReadOnlyList<LearningCurveEfficiencyModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"LearningCurveEfficiencies";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetLearningCurveEfficienciesQueryHandler : IRequestHandler<GetLearningCurveEfficienciesQuery, PagedResponse<IReadOnlyList<LearningCurveEfficiencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILearningCurveEfficiencyRepository _repository;
        public GetLearningCurveEfficienciesQueryHandler(IMapper mapper,
            ILearningCurveEfficiencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LearningCurveEfficiencyModel>>> Handle(GetLearningCurveEfficienciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LearningCurveEfficiencyParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(LearningCurveEfficiencyParameter.Code), nameof(LearningCurveEfficiencyParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<LearningCurveEfficiencyParameter, LearningCurveEfficiencyModel>(validFilter);
        }
    }
}
