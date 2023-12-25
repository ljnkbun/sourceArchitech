using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.Buyers;
using Shopfloor.Material.Application.Parameters.Buyers;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.Buyers
{
    public class GetCodeNameBuyersQuery : IRequest<PagedResponse<IReadOnlyList<BuyerDropdownModel>>>, ICacheableMediatrQuery
    {
        #region Default properties

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string SearchTerm { get; set; }

        public string OrderBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedUserId { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public bool? IsActive { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"GetCodeNameBuyers";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetCodeNameBuyersQueryHandler : IRequestHandler<GetCodeNameBuyersQuery, PagedResponse<IReadOnlyList<BuyerDropdownModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IBuyerRepository _repository;

        public GetCodeNameBuyersQueryHandler(IMapper mapper,
            IBuyerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<BuyerDropdownModel>>> Handle(GetCodeNameBuyersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<BuyerParameter>(request);
            validFilter.SetSearchProps(new List<string> { "Code", "Name" });
            return await _repository.GetModelPagedReponseAsync<BuyerParameter, BuyerDropdownModel>(validFilter);
        }
    }
}