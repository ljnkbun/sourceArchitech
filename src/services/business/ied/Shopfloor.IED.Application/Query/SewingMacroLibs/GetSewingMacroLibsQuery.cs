using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacroLibs;
using Shopfloor.IED.Application.Parameters.SewingMacroLibs;
using Shopfloor.IED.Application.Parameters.SewingTaskLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMacroLibs
{
    public class GetSewingMacroLibsQuery : IRequest<PagedResponse<IReadOnlyList<SewingMacroLibModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? FolderTreeId { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalBasicMinutes { get; set; }
        public decimal? NoneMachineTime { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingMacroLibs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingMacroLibsQueryHandler : IRequestHandler<GetSewingMacroLibsQuery, PagedResponse<IReadOnlyList<SewingMacroLibModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingMacroLibRepository _repository;
        public GetSewingMacroLibsQueryHandler(IMapper mapper,
            ISewingMacroLibRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingMacroLibModel>>> Handle(GetSewingMacroLibsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingMacroLibParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingTaskLibParameter.Code), nameof(SewingTaskLibParameter.Name), nameof(SewingTaskLibParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingMacroLibParameter, SewingMacroLibModel>(validFilter);
        }
    }
}
