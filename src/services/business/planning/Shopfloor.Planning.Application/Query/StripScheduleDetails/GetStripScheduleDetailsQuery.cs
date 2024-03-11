using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.StripScheduleDetails;
using Shopfloor.Planning.Application.Parameters.StripScheduleDetails;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripScheduleDetails
{
    public class GetStripScheduleDetailsQuery : IRequest<PagedResponse<IReadOnlyList<StripScheduleDetailModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int? PorDetailId { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int? StripScheduleId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"StripScheduleDetails";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetStripScheduleDetailsQueryHandler : IRequestHandler<GetStripScheduleDetailsQuery, PagedResponse<IReadOnlyList<StripScheduleDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripScheduleDetailRepository _repository;
        public GetStripScheduleDetailsQueryHandler(IMapper mapper,
            IStripScheduleDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripScheduleDetailModel>>> Handle(GetStripScheduleDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripScheduleDetailParameter>(request);
            validFilter.SetSearchProps(new string[]
            {
                nameof(StripScheduleDetailParameter.Color),
                nameof(StripScheduleDetailParameter.Size),
                nameof(StripScheduleDetailParameter.Quantity),
                nameof(StripScheduleDetailParameter.RemainingQuantity),
                nameof(StripScheduleDetailParameter.StripScheduleId)
            }.ToList());
            return await _repository.GetModelPagedReponseAsync<StripScheduleDetailParameter, StripScheduleDetailModel>(validFilter);
        }
    }
}
