using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Suppliers;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Parameters.Suppliers;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Suppliers
{
    public class GetSuppliersQuery : IRequest<PagedResponse<IReadOnlyList<SupplierModel>>>, ICacheableMediatrQuery
    {
        public string WFXSupplierId { get; set; }
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
        public string CacheKey => $"Suppliers";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, PagedResponse<IReadOnlyList<SupplierModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _repository;
        public GetSuppliersQueryHandler(IMapper mapper,
            ISupplierRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SupplierModel>>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SupplierParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SupplierParameter.WFXSupplierId), nameof(SupplierParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SupplierParameter, SupplierModel>(validFilter);
        }
    }
}
