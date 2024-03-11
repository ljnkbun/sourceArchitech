using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Parameters.SewingEfficiencyProfiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingEfficiencyProfiles
{
    public class GetSewingEfficiencyProfilesQuery : IRequest<PagedResponse<IReadOnlyList<SewingEfficiencyProfileModel>>>, ICacheableMediatrQuery
    {
        public string Name { get; set; }
        public decimal? PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal? Contingency { get; set; }
        public bool? IsDefault { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingEfficiencyProfiles";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetSewingEfficiencyProfilesQueryHandler : IRequestHandler<GetSewingEfficiencyProfilesQuery, PagedResponse<IReadOnlyList<SewingEfficiencyProfileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingEfficiencyProfileRepository _repository;

        public GetSewingEfficiencyProfilesQueryHandler(IMapper mapper,
            ISewingEfficiencyProfileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingEfficiencyProfileModel>>> Handle(GetSewingEfficiencyProfilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingEfficiencyProfileParameter>(request);
            return await _repository.GetModelSingleQueryPagedReponseAsync<SewingEfficiencyProfileParameter, SewingEfficiencyProfileModel>(validFilter);
        }
    }
}