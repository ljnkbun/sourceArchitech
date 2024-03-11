using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingReportSettings
{
    public class GetWeavingReportSettingQuery : IRequest<Response<WeavingReportSetting>>
    {
        public int Id { get; set; }
    }

    public class GetWeavingReportSettingQueryHandler : IRequestHandler<GetWeavingReportSettingQuery, Response<WeavingReportSetting>>
    {
        private readonly IWeavingReportSettingRepository _repository;

        public GetWeavingReportSettingQueryHandler(IWeavingReportSettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WeavingReportSetting>> Handle(GetWeavingReportSettingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) return new($"WeavingReportSetting Not Found (Id:{query.Id}).");
            return new Response<WeavingReportSetting>(entity);
        }
    }
}