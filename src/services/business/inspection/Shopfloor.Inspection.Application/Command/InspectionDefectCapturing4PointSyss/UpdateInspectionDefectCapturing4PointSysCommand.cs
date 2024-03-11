using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss
{
    public class UpdateInspectionDefectCapturing4PointSysCommand : IRequest<Response<int>>
    {
        public int Inpection4PointSysId { get; set; }
        public int QCDefectId { get; set; }
        public int? DefectQtyOne { get; set; }
        public int? DefectQtyTwo { get; set; }
        public int? DefectQtyThree { get; set; }
        public int? DefectQtyFour { get; set; }
        public int? MinorOne { get; set; }
        public int? MinorTwo { get; set; }
        public int? MinorThree { get; set; }
        public int? MinorFour { get; set; }
        public int? MajorOne { get; set; }
        public int? MajorTwo { get; set; }
        public int? MajorThree { get; set; }
        public int? MajorFour { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateInspectionDefectError4PointSysCommand> InspectionDefectError4PointSyss { get; set; }
    }
    public class UpdateInspectionDefectCapturing4PointSysCommandHandler : IRequestHandler<UpdateInspectionDefectCapturing4PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturing4PointSysRepository _repository;
        public UpdateInspectionDefectCapturing4PointSysCommandHandler(IInspectionDefectCapturing4PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionDefectCapturing4PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionDefectCapturing4PointSys Not Found.");
            entity.IsActive = command.IsActive;
            entity.Inpection4PointSysId = command.Inpection4PointSysId;
            entity.QCDefectId = command.QCDefectId;
            entity.DefectQtyOne = command.DefectQtyOne;
            entity.DefectQtyTwo = command.DefectQtyTwo;
            entity.DefectQtyThree = command.DefectQtyThree;
            entity.DefectQtyFour = command.DefectQtyFour;
            entity.MinorOne = command.MinorOne;
            entity.MinorTwo = command.MinorTwo;
            entity.MinorThree = command.MinorThree;
            entity.MinorFour = command.MinorFour;
            entity.MajorOne = command.MajorOne;
            entity.MajorTwo = command.MajorTwo;
            entity.MajorThree = command.MajorThree;
            entity.MajorFour = command.MajorFour;
            entity.ProblemRootCauseId = command.ProblemRootCauseId;
            entity.ProblemCorrectiveActionId = command.ProblemCorrectiveActionId;
            entity.ProblemTimelineId = command.ProblemTimelineId;
            entity.PersonInChargeId = command.PersonInChargeId;
            entity.AttachmentId = command.AttachmentId;
            entity.Remark = command.Remark;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
