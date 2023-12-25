using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Certificates;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.Certificates;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Certificates
{
    public class GetCertificatesQuery : IRequest<PagedResponse<IReadOnlyList<CertificateModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Certificates";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCertificatesQueryHandler : IRequestHandler<GetCertificatesQuery, PagedResponse<IReadOnlyList<CertificateModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _repository;
        public GetCertificatesQueryHandler(IMapper mapper,
            ICertificateRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CertificateModel>>> Handle(GetCertificatesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CertificateParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(CertificateParameter.Code), nameof(CertificateParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<CertificateParameter, CertificateModel>(validFilter);
        }
    }
}
