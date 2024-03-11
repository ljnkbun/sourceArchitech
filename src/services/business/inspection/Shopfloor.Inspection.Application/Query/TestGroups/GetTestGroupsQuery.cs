using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.TestGroups;
using Shopfloor.Inspection.Application.Parameters.TestGroups;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Query.TestGroups
{
    public class GetTestGroupsQuery : IRequest<PagedResponse<IReadOnlyList<TestGroupModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public GroupType? GroupType { get; set; }
		public bool? Mandatory { get; set; }
		public string Description { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetTestGroupsQueryHandler : IRequestHandler<GetTestGroupsQuery, PagedResponse<IReadOnlyList<TestGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ITestGroupRepository _repository;
        public GetTestGroupsQueryHandler(IMapper mapper,
            ITestGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<TestGroupModel>>> Handle(GetTestGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<TestGroupParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(TestGroupParameter.Code), nameof(TestGroupParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<TestGroupParameter, TestGroupModel>(validFilter);
        }
    }
}
