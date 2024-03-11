using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.OrderEfficiencies;
using Shopfloor.Planning.Application.Parameters.OrderEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.OrderEfficiencies
{
    public class GetOrderEfficienciesQuery : IRequest<PagedResponse<IReadOnlyList<OrderEfficiencyModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OCNo { get; set; }
        public decimal EfficiencyValue { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"OrderEfficiencies";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetOrderEfficienciesQueryHandler : IRequestHandler<GetOrderEfficienciesQuery, PagedResponse<IReadOnlyList<OrderEfficiencyModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderEfficiencyRepository _repository;
        public GetOrderEfficienciesQueryHandler(IMapper mapper,
            IOrderEfficiencyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<OrderEfficiencyModel>>> Handle(GetOrderEfficienciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<OrderEfficiencyParameter>(request);            
            return await _repository.GetModelPagedReponseAsync<OrderEfficiencyParameter, OrderEfficiencyModel>(validFilter);
        }
    }
}
