using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingReportSettingDetails;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingReportSettings
{
    public class LockWeavingReportSettingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class LockWeavingReportSettingCommandHandler : IRequestHandler<LockWeavingReportSettingCommand, Response<int>>
    {
        private readonly IWeavingReportSettingRepository _repository;

        public LockWeavingReportSettingCommandHandler(IWeavingReportSettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(LockWeavingReportSettingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingReportSetting Not Found.");
            entity.Locked = !entity.Locked;
            await _repository.UpdateAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}