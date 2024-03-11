using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Parameters.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMachineEfficiencyProfiles
{
    public class GetSewingMachineEfficiencyProfilesQuery : IRequest<PagedResponse<IReadOnlyList<SewingMachineEfficiencyProfileModel>>>, ICacheableMediatrQuery
    {
        public int? SewingEfficiencyProfileId { get; set; }
        public int? MachineId { get; set; }
        public string MachineName { get; set; }

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
        public string CacheKey => $"SewingMachineEfficiencyProfiles";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetSewingMachineEfficiencyProfilesQueryHandler : IRequestHandler<GetSewingMachineEfficiencyProfilesQuery, PagedResponse<IReadOnlyList<SewingMachineEfficiencyProfileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingMachineEfficiencyProfileRepository _repository;

        public GetSewingMachineEfficiencyProfilesQueryHandler(IMapper mapper,
            ISewingMachineEfficiencyProfileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingMachineEfficiencyProfileModel>>> Handle(GetSewingMachineEfficiencyProfilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingMachineEfficiencyProfileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingMachineEfficiencyProfileParameter, SewingMachineEfficiencyProfileModel>(validFilter);
        }
    }
}