using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingReportSettings;
using Shopfloor.IED.Application.Parameters.WeavingReportSettings;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingReportSettings
{
    public class GetWeavingReportSettingsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingReportSettingModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public SettingType? SettingType { get; set; }
        public bool? Locked { get; set; }
        public int? NumberOfSplit { get; set; }
        public int? Repeat { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetWeavingReportSettingsQueryHandler : IRequestHandler<GetWeavingReportSettingsQuery, PagedResponse<IReadOnlyList<WeavingReportSettingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingReportSettingRepository _repository;

        public GetWeavingReportSettingsQueryHandler(IMapper mapper,
            IWeavingReportSettingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingReportSettingModel>>> Handle(GetWeavingReportSettingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingReportSettingParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingReportSettingParameter, WeavingReportSettingModel>(validFilter);
        }
    }
}