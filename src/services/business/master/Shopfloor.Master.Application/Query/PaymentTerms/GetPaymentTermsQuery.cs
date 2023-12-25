using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.PaymentTerms;
using Shopfloor.Master.Application.Parameters.Micronaires;
using Shopfloor.Master.Application.Parameters.PaymentTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PaymentTerms
{
    public class GetPaymentTermsQuery : IRequest<PagedResponse<IReadOnlyList<PaymentTermModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CreditDays { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"PaymentTerms";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPaymentTermsQueryHandler : IRequestHandler<GetPaymentTermsQuery, PagedResponse<IReadOnlyList<PaymentTermModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTermRepository _repository;
        public GetPaymentTermsQueryHandler(IMapper mapper,
            IPaymentTermRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PaymentTermModel>>> Handle(GetPaymentTermsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PaymentTermParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(PaymentTermParameter.Code), nameof(PaymentTermParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<PaymentTermParameter, PaymentTermModel>(validFilter);
        }
    }
}
