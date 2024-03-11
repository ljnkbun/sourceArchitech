using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.SubCategories;
using Shopfloor.Master.Application.Parameters.Structures;
using Shopfloor.Master.Application.Parameters.SubCategories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SubCategories
{
    public class GetSubCategoriesQuery : IRequest<PagedResponse<IReadOnlyList<SubCategoryModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public string SubCategoryGroupName { get; set; }
        public string SubCategoryGroupCode { get; set; }
        public string ExciseTarrifNo { get; set; }
        public bool? PackagingUnit { get; set; }
        public bool? ByPassPriceList { get; set; }
        public bool? DefaultInactiveIndent { get; set; }
        public int? ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductGroupCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SubCategories";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSubCategorysQueryHandler : IRequestHandler<GetSubCategoriesQuery, PagedResponse<IReadOnlyList<SubCategoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryRepository _repository;
        public GetSubCategorysQueryHandler(IMapper mapper,
            ISubCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SubCategoryModel>>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SubCategoryParameter>(request);
            validFilter.SetSearchProps(new string[] {
                nameof(SubCategoryParameter.Code), nameof(SubCategoryParameter.Name) , nameof(SubCategoryParameter.SubCategoryGroupId) , nameof(SubCategoryParameter.ExciseTarrifNo)
                , nameof(SubCategoryParameter.PackagingUnit) , nameof(SubCategoryParameter.ByPassPriceList) , nameof(SubCategoryParameter.DefaultInactiveIndent) 
                , nameof(SubCategoryParameter.ProductGroupId)
                , nameof(SubCategoryParameter.ProductGroupName) }.ToList());
            return await _repository.GetModelPagedAsync<SubCategoryParameter, SubCategoryModel>(validFilter, request.ProductGroupName);
        }
    }
}
