using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.ProfileEfficiencies;
using Shopfloor.Planning.Application.Parameters.ProfileEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.ProfileEfficiencies
{
    public class GetProfileEfficienciesQuery : IRequest<PagedResponse<IReadOnlyList<ProfileEfficiencyModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProductGroupId { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProfileEfficiencies";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProfileEfficienciesQueryHandler : IRequestHandler<GetProfileEfficienciesQuery, PagedResponse<IReadOnlyList<ProfileEfficiencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEfficiencyRepository _repository;
        public GetProfileEfficienciesQueryHandler(IMapper mapper,
            IProfileEfficiencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProfileEfficiencyModel>>> Handle(GetProfileEfficienciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProfileEfficiencyParameter>(request);
            validFilter.SetSearchProps(new string[]
            {
                nameof(ProfileEfficiencyParameter.Code),
                nameof(ProfileEfficiencyParameter.Name),
                nameof(ProfileEfficiencyParameter.ProductGroupId),
                nameof(ProfileEfficiencyParameter.ProductGroupCode),
                nameof(ProfileEfficiencyParameter.ProductGroupName),
                nameof(ProfileEfficiencyParameter.CategoryId),
                nameof(ProfileEfficiencyParameter.CategoryCode),
                nameof(ProfileEfficiencyParameter.CategoryName)
            }.ToList());
            return await _repository.GetProfileEfficiencyModelAsync<ProfileEfficiencyParameter, ProfileEfficiencyModel>(validFilter);
        }
    }
}
