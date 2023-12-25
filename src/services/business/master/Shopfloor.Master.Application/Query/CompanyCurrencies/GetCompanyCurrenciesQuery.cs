using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ColorDefinitions;
using Shopfloor.Master.Application.Models.CompanyCurrencies;
using Shopfloor.Master.Application.Parameters.CompanyCurrencies;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CompanyCurrencies
{
    public class GetCompanyCurrenciesQuery : IRequest<PagedResponse<IReadOnlyList<CompanyCurrencyModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"CompanyCurrencies";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCompanyCurrenciesQueryHandler : IRequestHandler<GetCompanyCurrenciesQuery, PagedResponse<IReadOnlyList<CompanyCurrencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCurrencyRepository _repository;
        public GetCompanyCurrenciesQueryHandler(IMapper mapper,
            ICompanyCurrencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CompanyCurrencyModel>>> Handle(GetCompanyCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CompanyCurrencyParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CompanyCurrencyParameter.Code), nameof(CompanyCurrencyParameter.Name), nameof(CompanyCurrencyParameter.RateExchange), nameof(CompanyCurrencyParameter.ValidFrom), nameof(CompanyCurrencyParameter.Symbol) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CompanyCurrencyParameter, CompanyCurrencyModel>(validFilter);
        }
    }
}
