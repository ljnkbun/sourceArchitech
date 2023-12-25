using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.SizeOrWidthRanges;
using Shopfloor.Master.Application.Parameters.ShipmentTerms;
using Shopfloor.Master.Application.Parameters.SizeOrWidthRanges;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SizeOrWidthRanges
{
    public class GetSizeOrWidthRangesQuery : IRequest<PagedResponse<IReadOnlyList<SizeOrWidthRangeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public string Inseam { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SizeOrWidthRanges";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSizeOrWidthRangesQueryHandler : IRequestHandler<GetSizeOrWidthRangesQuery, PagedResponse<IReadOnlyList<SizeOrWidthRangeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISizeOrWidthRangeRepository _repository;
        public GetSizeOrWidthRangesQueryHandler(IMapper mapper,
            ISizeOrWidthRangeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SizeOrWidthRangeModel>>> Handle(GetSizeOrWidthRangesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SizeOrWidthRangeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(SizeOrWidthRangeParameter.Code), nameof(SizeOrWidthRangeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<SizeOrWidthRangeParameter, SizeOrWidthRangeModel>(validFilter);
        }
    }
}
