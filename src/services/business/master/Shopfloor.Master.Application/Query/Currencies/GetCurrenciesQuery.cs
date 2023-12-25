using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Currencies;
using Shopfloor.Master.Application.Parameters.CountTypes;
using Shopfloor.Master.Application.Parameters.Currencies;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Currencies
{
    public class GetCurrenciesQuery : IRequest<PagedResponse<IReadOnlyList<CurrencyModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Currencies";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCurrenciesQueryQueryHandler : IRequestHandler<GetCurrenciesQuery, PagedResponse<IReadOnlyList<CurrencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _repository;
        public GetCurrenciesQueryQueryHandler(IMapper mapper,
            ICurrencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CurrencyModel>>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CurrencyParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CurrencyParameter.Code), nameof(CurrencyParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CurrencyParameter, CurrencyModel>(validFilter);
        }
    }
}
