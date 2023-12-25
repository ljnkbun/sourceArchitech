using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ProductGroups;
using Shopfloor.Master.Application.Parameters.ProductGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ProductGroups
{
    public class GetProductGroupsQuery : IRequest<PagedResponse<IReadOnlyList<ProductGroupModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProductGroups";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProductGroupsQueryHandler : IRequestHandler<GetProductGroupsQuery, PagedResponse<IReadOnlyList<ProductGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _repository;
        public GetProductGroupsQueryHandler(IMapper mapper,
            IProductGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProductGroupModel>>> Handle(GetProductGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProductGroupParameter>(request);
            validFilter.SetSearchProps(new string[]
            {
                nameof(ProductGroupParameter.Code),
                nameof(ProductGroupParameter.Name),
                nameof(ProductGroupParameter.MaterialTypeId),
                nameof(ProductGroupParameter.CategoryId)
            }.ToList());
            return await _repository.GetModelPagedReponseAsync<ProductGroupParameter, ProductGroupModel>(validFilter);
        }
    }
}
