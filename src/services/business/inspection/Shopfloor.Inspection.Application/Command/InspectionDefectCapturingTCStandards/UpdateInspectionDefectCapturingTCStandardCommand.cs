using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards
{
    public class UpdateInspectionDefectCapturingTCStandardCommand : IRequest<Response<int>>
    {
        public int InpectionTCStandardId { get; set; }
		public int QCDefectId { get; set; }
		public int Defect { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateInspectionDefectCapturingTCStandardCommandHandler : IRequestHandler<UpdateInspectionDefectCapturingTCStandardCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturingTCStandardRepository _repository;
        public UpdateInspectionDefectCapturingTCStandardCommandHandler(IInspectionDefectCapturingTCStandardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionDefectCapturingTCStandardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionDefectCapturingTCStandard Not Found.");
            entity.IsActive = command.IsActive;
            entity.InpectionTCStandardId = command.InpectionTCStandardId;
			entity.QCDefectId = command.QCDefectId;
			entity.Defect = command.Defect;
			entity.AttachmentId = command.AttachmentId;
			entity.Remark = command.Remark;
			entity.ProblemRootCauseId = command.ProblemRootCauseId;
			entity.ProblemCorrectiveActionId = command.ProblemCorrectiveActionId;
			entity.ProblemTimelineId = command.ProblemTimelineId;
			entity.PersonInChargeId = command.PersonInChargeId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
