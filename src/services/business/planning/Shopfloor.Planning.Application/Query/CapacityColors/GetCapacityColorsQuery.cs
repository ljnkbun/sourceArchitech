using AutoMapper;
using MediatR;
using Shopfloor.Planning.Application.Models.CapacityColors;
using Shopfloor.Planning.Application.Parameters.CapacityColors;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.CapacityColors
{
    public class GetCapacityColorsQuery : IRequest<PagedResponse<IReadOnlyList<CapacityColorModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Color { get; set; }
		public decimal? FromRange { get; set; }
		public decimal? ToRange { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"CapacityColor";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetCapacityColorsQueryHandler : IRequestHandler<GetCapacityColorsQuery, PagedResponse<IReadOnlyList<CapacityColorModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICapacityColorRepository _repository;
        public GetCapacityColorsQueryHandler(IMapper mapper,
            ICapacityColorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<CapacityColorModel>>> Handle(GetCapacityColorsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<CapacityColorParameter>(request);
            return await _repository.GetModelPagedReponseAsync<CapacityColorParameter, CapacityColorModel>(validFilter);
        }
    }
}
