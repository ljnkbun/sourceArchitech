using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Themes;
using Shopfloor.Master.Application.Parameters.Themes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Themes
{
    public class GetThemesQuery : IRequest<PagedResponse<IReadOnlyList<ThemeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Themes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetThemesQueryHandler : IRequestHandler<GetThemesQuery, PagedResponse<IReadOnlyList<ThemeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IThemeRepository _repository;
        public GetThemesQueryHandler(IMapper mapper,
            IThemeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ThemeModel>>> Handle(GetThemesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ThemeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ThemeParameter.Code), nameof(ThemeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ThemeParameter, ThemeModel>(validFilter);
        }
    }
}
