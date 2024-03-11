using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettingDetails
{
    public class UpdateWeavingReportSettingDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WeavingReportSettingId { get; set; }
        public int GroupIndex { get; set; }
        public string Split { get; set; }
        public int Repeat { get; set; }
        public bool IsActive { set; get; }
    }

    public class UpdateWeavingReportSettingDetailCommandHandler : IRequestHandler<UpdateWeavingReportSettingDetailCommand, Response<int>>
    {
        private readonly IWeavingReportSettingDetailRepository _repository;

        public UpdateWeavingReportSettingDetailCommandHandler(IWeavingReportSettingDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateWeavingReportSettingDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingReportSettingDetail Not Found.");

            entity.WeavingReportSettingId = command.WeavingReportSettingId;
            entity.GroupIndex = command.GroupIndex;
            entity.Split = command.Split;
            entity.Repeat = command.Repeat;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}