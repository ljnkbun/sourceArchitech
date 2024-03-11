using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.StripSchedules;
using Shopfloor.Planning.Application.Parameters.StripSchedules;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripSchedules
{
    public class GetStripSchedulesQuery : IRequest<PagedResponse<IReadOnlyList<StripScheduleModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public decimal? ProfileEfficiencyValue { get; set; }
        public decimal? OrderEfficiencyValue { get; set; }
        public decimal? StripEfficiencyValue { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
        public string Gauge { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetStripSchedulesQueryHandler : IRequestHandler<GetStripSchedulesQuery, PagedResponse<IReadOnlyList<StripScheduleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripScheduleRepository _repository;
        public GetStripSchedulesQueryHandler(IMapper mapper,
            IStripScheduleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripScheduleModel>>> Handle(GetStripSchedulesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripScheduleParameter>(request);
            return await _repository.GetStripScheduleModelAsync<StripScheduleParameter, StripScheduleModel>(validFilter);
        }
    }
}
