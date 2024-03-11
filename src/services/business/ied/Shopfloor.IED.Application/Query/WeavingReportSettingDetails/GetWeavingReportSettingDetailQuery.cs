using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingReportSettingDetails
{
    public class GetWeavingReportSettingDetailQuery : IRequest<Response<WeavingReportSettingDetail>>
    {
        public int Id { get; set; }
    }

    public class GetWeavingReportSettingDetailQueryHandler : IRequestHandler<GetWeavingReportSettingDetailQuery, Response<WeavingReportSettingDetail>>
    {
        private readonly IWeavingReportSettingDetailRepository _repository;

        public GetWeavingReportSettingDetailQueryHandler(IWeavingReportSettingDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WeavingReportSettingDetail>> Handle(GetWeavingReportSettingDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingReportSettingDetail Not Found (Id:{query.Id}).");
            return new Response<WeavingReportSettingDetail>(entity);
        }
    }
}