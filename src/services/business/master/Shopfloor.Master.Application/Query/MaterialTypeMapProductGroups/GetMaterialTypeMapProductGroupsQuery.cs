using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.MaterialTypeMapProductGroups;
using Shopfloor.Master.Application.Parameters.MaterialTypeMapProductGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.MaterialTypeMapProductGroups
{
    public class GetMaterialTypeMapProductGroupsQuery : IRequest<PagedResponse<IReadOnlyList<MaterialTypeMapProductGroupModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public int? ProductGroupId { get; set; }
        public int? MaterialTypeId { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"MaterialTypeMapProductGroups";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMaterialTypeMapProductGroupsQueryHandler : IRequestHandler<GetMaterialTypeMapProductGroupsQuery, PagedResponse<IReadOnlyList<MaterialTypeMapProductGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeMapProductGroupRepository _repository;
        public GetMaterialTypeMapProductGroupsQueryHandler(IMapper mapper,
            IMaterialTypeMapProductGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MaterialTypeMapProductGroupModel>>> Handle(GetMaterialTypeMapProductGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MaterialTypeMapProductGroupParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(MaterialTypeMapProductGroupParameter.ProductGroupId), nameof(MaterialTypeMapProductGroupParameter.MaterialTypeId) }.ToList());
            return await _repository.GetModelPagedReponseAsync<MaterialTypeMapProductGroupParameter, MaterialTypeMapProductGroupModel>(validFilter);
        }
    }
}
