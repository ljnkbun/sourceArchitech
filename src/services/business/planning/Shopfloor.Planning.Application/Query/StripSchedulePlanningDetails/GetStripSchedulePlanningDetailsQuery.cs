using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Parameters.StripSchedulePlanningDetails;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripSchedulePlanningDetails
{
    public class GetStripSchedulePlanningDetailsQuery : IRequest<PagedResponse<IReadOnlyList<StripSchedulePlanningDetailModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? Date { get; set; }
        public decimal? WorkingHours { get; set; }
        public decimal? StandardCapacity { get; set; }
        public decimal? ActualCapacity { get; set; }
        public decimal? ReceivedCapacity { get; set; }
        public string Description { get; set; }
        public int? StripScheduleId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetStripSchedulePlanningDetailsQueryHandler : IRequestHandler<GetStripSchedulePlanningDetailsQuery, PagedResponse<IReadOnlyList<StripSchedulePlanningDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripSchedulePlanningDetailRepository _repository;
        public GetStripSchedulePlanningDetailsQueryHandler(IMapper mapper,
            IStripSchedulePlanningDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripSchedulePlanningDetailModel>>> Handle(GetStripSchedulePlanningDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripSchedulePlanningDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<StripSchedulePlanningDetailParameter, StripSchedulePlanningDetailModel>(validFilter);
        }
    }
}
