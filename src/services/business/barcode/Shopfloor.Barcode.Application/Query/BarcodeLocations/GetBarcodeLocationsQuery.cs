using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.BarcodeLocations;
using Shopfloor.Barcode.Application.Parameters.BarcodeLocations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.BarcodeLocations
{
    public class GetBarcodeLocationsQuery : IRequest<PagedResponse<IReadOnlyList<BarcodeLocationModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? LocationId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"BarcodeLocation";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetBarcodeLocationsQueryHandler : IRequestHandler<GetBarcodeLocationsQuery, PagedResponse<IReadOnlyList<BarcodeLocationModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IBarcodeLocationRepository _repository;
        public GetBarcodeLocationsQueryHandler(IMapper mapper,
            IBarcodeLocationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<BarcodeLocationModel>>> Handle(GetBarcodeLocationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<BarcodeLocationParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(BarcodeLocationParameter.LocationId), nameof(BarcodeLocationParameter.ArticleBarcodeId) }.ToList());
            return await _repository.GetModelPagedReponseAsync<BarcodeLocationParameter, BarcodeLocationModel>(validFilter);
        }
    }
}
