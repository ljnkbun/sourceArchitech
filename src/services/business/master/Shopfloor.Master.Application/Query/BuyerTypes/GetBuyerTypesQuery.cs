using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.BuyerTypes;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.BuyerTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.BuyerTypes
{
    public class GetBuyerTypesQuery : IRequest<PagedResponse<IReadOnlyList<BuyerTypeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"BuyerTypes";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetBuyerTypesQueryHandler : IRequestHandler<GetBuyerTypesQuery, PagedResponse<IReadOnlyList<BuyerTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IBuyerTypeRepository _repository;
        public GetBuyerTypesQueryHandler(IMapper mapper,
            IBuyerTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<BuyerTypeModel>>> Handle(GetBuyerTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<BuyerTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(BuyerTypeParameter.Code), nameof(BuyerTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<BuyerTypeParameter, BuyerTypeModel>(validFilter);
        }
    }
}
