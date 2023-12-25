using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacros;
using Shopfloor.IED.Application.Parameters.SewingMacros;
using Shopfloor.IED.Application.Parameters.SewingTaskLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMacros
{
    public class GetSewingMacrosQuery : IRequest<PagedResponse<IReadOnlyList<SewingMacroModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
        public string CacheKey => $"SewingMacros";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingMacrosQueryHandler : IRequestHandler<GetSewingMacrosQuery, PagedResponse<IReadOnlyList<SewingMacroModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingMacroRepository _repository;
        public GetSewingMacrosQueryHandler(IMapper mapper,
            ISewingMacroRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingMacroModel>>> Handle(GetSewingMacrosQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingMacroParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingTaskLibParameter.Code), nameof(SewingTaskLibParameter.Name), nameof(SewingTaskLibParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingMacroParameter, SewingMacroModel>(validFilter);
        }
    }
}
