using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturingStandards
{
    public class UpdateDefectCapturingStandardCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int Defect { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public string RootCauseIds { get; set; }
        public string CorrectiveActionIds { get; set; }

        public int? TimelineId { get; set; }
        public string PersonInChargeIds { get; set; }
    }
    public class UpdateDefectCapturingStandardCommandHandler : IRequestHandler<UpdateDefectCapturingStandardCommand, Response<int>>
    {
        private readonly IDefectCapturingStandardRepository _repository;
        public UpdateDefectCapturingStandardCommandHandler(IDefectCapturingStandardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateDefectCapturingStandardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DefectCapturingStandard Not Found.");

            entity.ProductionOutputId = command.ProductionOutputId;
            entity.QCDefectId = command.QCDefectId;
            entity.Defect = command.Defect;
            entity.AttachmentId = command.AttachmentId;
            entity.Remark = command.Remark;
            entity.RootCauseIds = command.RootCauseIds;
            entity.PersonInChargeIds = command.PersonInChargeIds;
            entity.CorrectiveActionIds = command.CorrectiveActionIds;
            entity.TimelineId = command.TimelineId;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
