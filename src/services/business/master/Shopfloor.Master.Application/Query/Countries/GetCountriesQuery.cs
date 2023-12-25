using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Countries;
using Shopfloor.Master.Application.Parameters.Countries;
using Shopfloor.Master.Application.Parameters.Counts;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Countries
{
    public class GetCountriesQuery : IRequest<PagedResponse<IReadOnlyList<CountryModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Countries";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCountriesQueryQueryHandler : IRequestHandler<GetCountriesQuery, PagedResponse<IReadOnlyList<CountryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _repository;
        public GetCountriesQueryQueryHandler(IMapper mapper,
            ICountryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CountryModel>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CountryParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CountryParameter.Code), nameof(CountryParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CountryParameter, CountryModel>(validFilter);
        }
    }
}
