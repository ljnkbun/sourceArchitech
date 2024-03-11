using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingReportSettingDetails;
using Shopfloor.IED.Application.Parameters.WeavingReportSettingDetails;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingReportSettingDetails
{
    public class GetWeavingReportSettingDetailsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingReportSettingDetailModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingReportSettingId { get; set; }
        public int? GroupIndex { get; set; }
        public string Split { get; set; }
        public int? Repeat { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetWeavingReportSettingDetailsQueryHandler : IRequestHandler<GetWeavingReportSettingDetailsQuery, PagedResponse<IReadOnlyList<WeavingReportSettingDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingReportSettingDetailRepository _repository;

        public GetWeavingReportSettingDetailsQueryHandler(IMapper mapper,
            IWeavingReportSettingDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingReportSettingDetailModel>>> Handle(GetWeavingReportSettingDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingReportSettingDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingReportSettingDetailParameter, WeavingReportSettingDetailModel>(validFilter);
        }
    }
}