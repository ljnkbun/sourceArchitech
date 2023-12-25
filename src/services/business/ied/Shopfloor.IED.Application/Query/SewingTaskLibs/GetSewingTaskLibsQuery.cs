using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingTaskLibs;
using Shopfloor.IED.Application.Parameters.SewingTaskLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingTaskLibs
{
    public class GetSewingTaskLibsQuery : IRequest<PagedResponse<IReadOnlyList<SewingTaskLibModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Freq { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundelTMU { get; set; }
        public decimal? TotalTMU { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingTaskLibs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingTaskLibsQueryHandler : IRequestHandler<GetSewingTaskLibsQuery, PagedResponse<IReadOnlyList<SewingTaskLibModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingTaskLibRepository _repository;
        public GetSewingTaskLibsQueryHandler(IMapper mapper,
            ISewingTaskLibRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingTaskLibModel>>> Handle(GetSewingTaskLibsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingTaskLibParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SewingTaskLibParameter.Code), nameof(SewingTaskLibParameter.Name), nameof(SewingTaskLibParameter.Description) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SewingTaskLibParameter, SewingTaskLibModel>(validFilter);
        }
    }
}
