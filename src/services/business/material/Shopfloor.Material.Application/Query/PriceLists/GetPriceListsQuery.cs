using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.PriceLists;
using Shopfloor.Material.Application.Parameters.PriceLists;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.PriceLists
{
    public class GetPriceListsQuery : IRequest<PagedResponse<IReadOnlyList<PriceListModel>>>, ICacheableMediatrQuery
    {
        public string RequestNo { get; set; }

        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public ProcessStatus? Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public string ReasonReject { get; set; }

        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }

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

        public string CacheKey => $"PriceLists";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetPriceListsQueryHandler : IRequestHandler<GetPriceListsQuery, PagedResponse<IReadOnlyList<PriceListModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IPriceListRepository _repository;

        public GetPriceListsQueryHandler(IMapper mapper,
            IPriceListRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PriceListModel>>> Handle(GetPriceListsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PriceListParameter>(request);
            return await _repository.GetPriceListPagedReponseAsync<PriceListParameter, PriceListModel>(validFilter, request.CreatedFrom, request.CreatedTo);
        }
    }
}