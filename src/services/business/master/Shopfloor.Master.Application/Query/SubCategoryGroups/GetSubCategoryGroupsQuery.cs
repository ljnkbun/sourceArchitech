using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.SubCategoryGroups;
using Shopfloor.Master.Application.Parameters.Structures;
using Shopfloor.Master.Application.Parameters.SubCategoryGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SubCategoryGroups
{
    public class GetSubCategoryGroupsQuery : IRequest<PagedResponse<IReadOnlyList<SubCategoryGroupModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"SubCategoryGroups";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSubCategoryGroupsQueryHandler : IRequestHandler<GetSubCategoryGroupsQuery, PagedResponse<IReadOnlyList<SubCategoryGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryGroupRepository _repository;
        public GetSubCategoryGroupsQueryHandler(IMapper mapper,
            ISubCategoryGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SubCategoryGroupModel>>> Handle(GetSubCategoryGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SubCategoryGroupParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SubCategoryGroupParameter.Code), nameof(SubCategoryGroupParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SubCategoryGroupParameter, SubCategoryGroupModel>(validFilter);
        }
    }
}
