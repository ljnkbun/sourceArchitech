using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.Tests;
using Shopfloor.Inspection.Application.Parameters.Tests;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.Tests
{
    public class GetTestsQuery : IRequest<PagedResponse<IReadOnlyList<TestModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public int? TestGroupId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Test";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetTestsQueryHandler : IRequestHandler<GetTestsQuery, PagedResponse<IReadOnlyList<TestModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _repository;
        public GetTestsQueryHandler(IMapper mapper,
            ITestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<TestModel>>> Handle(GetTestsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<TestParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(TestParameter.Code), nameof(TestParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<TestParameter, TestModel>(validFilter);
        }
    }
}
