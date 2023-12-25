using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Ports;
using Shopfloor.Master.Application.Parameters.PaymentTerms;
using Shopfloor.Master.Application.Parameters.Ports;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Ports
{
    public class GetPortsQuery : IRequest<PagedResponse<IReadOnlyList<PortModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? PortOfLoading { get; set; }
        public bool? PortOfDischarge { get; set; }
        public bool? PortOfReceiptByPreCarrier { get; set; }
        public int? CountryId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Ports";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPortsQueryHandler : IRequestHandler<GetPortsQuery, PagedResponse<IReadOnlyList<PortModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _repository;
        public GetPortsQueryHandler(IMapper mapper,
            IPortRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PortModel>>> Handle(GetPortsQuery request, CancellationToken cancellationToken)
        {

            var validFilter = _mapper.Map<PortParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(PortParameter.Code), nameof(PortParameter.Name), nameof(PortParameter.PortOfLoading), nameof(PortParameter.PortOfDischarge), nameof(PortParameter.PortOfReceiptByPreCarrier), nameof(PortParameter.CountryId) }.ToList());
            return await _repository.GetModelPagedReponseAsync<PortParameter, PortModel>(validFilter);
        }
    }
}
