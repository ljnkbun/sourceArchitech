using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.DynamicColumns;
using Shopfloor.Material.Application.Parameters.DynamicColumns;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.DynamicColumns
{
    public class GetDynamicColumnsQuery : IRequest<PagedResponse<IReadOnlyList<DynamicColumnModel>>>, ICacheableMediatrQuery
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public FieldType? FieldType { get; set; }

        public bool? IsContent { get; set; }

        public bool? IsRequired { get; set; }

        public string CategoryCode { get; set; }

        public int? DisplayIndex { get; set; }

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

        public string CacheKey => $"DynamicColumns";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetDynamicColumnsQueryHandler : IRequestHandler<GetDynamicColumnsQuery, PagedResponse<IReadOnlyList<DynamicColumnModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IDynamicColumnRepository _repository;

        public GetDynamicColumnsQueryHandler(IMapper mapper,
            IDynamicColumnRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DynamicColumnModel>>> Handle(GetDynamicColumnsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DynamicColumnParameter>(request);
            return await _repository.GetDynamicColumnPagedReponseAsync<DynamicColumnParameter, DynamicColumnModel>(validFilter, request.CreatedFrom, request.CreatedTo);
        }
    }
}