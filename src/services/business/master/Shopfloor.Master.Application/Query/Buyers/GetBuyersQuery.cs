using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Buyers;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.Buyers;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Buyers
{
    public class GetBuyersQuery : IRequest<PagedResponse<IReadOnlyList<BuyerModel>>>, ICacheableMediatrQuery
    {
        public string WFXBuyerId { get; set; }
        public string Name { get; set; }
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
        public string CacheKey => $"Buyers";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetBuyersQueryHandler : IRequestHandler<GetBuyersQuery, PagedResponse<IReadOnlyList<BuyerModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IBuyerRepository _repository;
        public GetBuyersQueryHandler(IMapper mapper,
            IBuyerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<BuyerModel>>> Handle(GetBuyersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<BuyerParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(BuyerParameter.WFXBuyerId), nameof(BuyerParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<BuyerParameter, BuyerModel>(validFilter);
        }
    }
}
