using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettingDetails
{
    public class DeleteWeavingReportSettingDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWeavingReportSettingDetailCommandHandler : IRequestHandler<DeleteWeavingReportSettingDetailCommand, Response<int>>
    {
        private readonly IWeavingReportSettingDetailRepository _repository;

        public DeleteWeavingReportSettingDetailCommandHandler(IWeavingReportSettingDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteWeavingReportSettingDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingReportSettingDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}