using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.TestEntities;
using Shopfloor.Inspection.Application.Parameters.TestEntities;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.TestEntities
{
    public class GetTestEntitiesQuery : IRequest<PagedResponse<IReadOnlyList<TestEntityModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType? Type { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"TestEntities";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetTestEntitiesQueryHandler : IRequestHandler<GetTestEntitiesQuery, PagedResponse<IReadOnlyList<TestEntityModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ITestEntityRepository _repository;
        public GetTestEntitiesQueryHandler(IMapper mapper,
            ITestEntityRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<TestEntityModel>>> Handle(GetTestEntitiesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<TestEntityParameter>(request);
            return await _repository.GetModelPagedReponseAsync<TestEntityParameter, TestEntityModel>(validFilter);
        }
    }
}
