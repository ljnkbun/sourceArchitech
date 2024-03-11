using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettings
{
    public class DeleteWeavingReportSettingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWeavingReportSettingCommandHandler : IRequestHandler<DeleteWeavingReportSettingCommand, Response<int>>
    {
        private readonly IWeavingReportSettingRepository _repository;

        public DeleteWeavingReportSettingCommandHandler(IWeavingReportSettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteWeavingReportSettingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingReportSetting Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}