using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.ProfileEfficiencyDetails;
using Shopfloor.Planning.Application.Parameters.ProfileEfficiencyDetails;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.ProfileEfficiencyDetails
{
    public class GetProfileEfficiencyDetailsQuery : IRequest<PagedResponse<IReadOnlyList<ProfileEfficiencyDetailModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? ProfileEfficiencyId { get; set; }
        public decimal? EfficiencyValue { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProfileEfficiencyDetails";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProfileEfficiencyDetailsQueryHandler : IRequestHandler<GetProfileEfficiencyDetailsQuery, PagedResponse<IReadOnlyList<ProfileEfficiencyDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEfficiencyDetailRepository _repository;
        public GetProfileEfficiencyDetailsQueryHandler(IMapper mapper,
            IProfileEfficiencyDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProfileEfficiencyDetailModel>>> Handle(GetProfileEfficiencyDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProfileEfficiencyDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ProfileEfficiencyDetailParameter, ProfileEfficiencyDetailModel>(validFilter);
        }
    }
}
