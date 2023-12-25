using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.DeliveryTerms;
using Shopfloor.Master.Application.Parameters.Currencies;
using Shopfloor.Master.Application.Parameters.DeliveryTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.DeliveryTerms
{
    public class GetDeliveryTermsQuery : IRequest<PagedResponse<IReadOnlyList<DeliveryTermModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"DeliveryTerms";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetDeliveryTermsQueryHandler : IRequestHandler<GetDeliveryTermsQuery, PagedResponse<IReadOnlyList<DeliveryTermModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryTermRepository _repository;
        public GetDeliveryTermsQueryHandler(IMapper mapper,
            IDeliveryTermRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DeliveryTermModel>>> Handle(GetDeliveryTermsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DeliveryTermParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(DeliveryTermParameter.Code), nameof(DeliveryTermParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<DeliveryTermParameter, DeliveryTermModel>(validFilter);
        }
    }
}
