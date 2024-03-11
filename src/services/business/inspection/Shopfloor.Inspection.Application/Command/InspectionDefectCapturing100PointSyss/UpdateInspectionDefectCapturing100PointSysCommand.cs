using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss
{
    public class UpdateInspectionDefectCapturing100PointSysCommand : IRequest<Response<int>>
    {
        public int Inpection100PointSysId { get; set; }
        public int QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critial { get; set; }
        public int? AttachmentId { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }
        public ICollection<UpdateInspectionDefectError100PointSysCommand> InspectionDefectError100PointSyss { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateInspectionDefectCapturing100PointSysCommandHandler : IRequestHandler<UpdateInspectionDefectCapturing100PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturing100PointSysRepository _repository;
        public UpdateInspectionDefectCapturing100PointSysCommandHandler(IInspectionDefectCapturing100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionDefectCapturing100PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionDefectCapturing100PointSys Not Found.");
            entity.IsActive = command.IsActive;
            entity.Inpection100PointSysId = command.Inpection100PointSysId;
            entity.QCDefectId = command.QCDefectId;
            entity.Minor = command.Minor;
            entity.Major = command.Major;
            entity.Critial = command.Critial;
            entity.AttachmentId = command.AttachmentId;
            entity.ProblemRootCauseId = command.ProblemRootCauseId;
            entity.ProblemCorrectiveActionId = command.ProblemCorrectiveActionId;
            entity.ProblemTimelineId = command.ProblemTimelineId;
            entity.PersonInChargeId = command.PersonInChargeId;
            entity.Remark = command.Remark;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
