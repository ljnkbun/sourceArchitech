using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturings
{
    public class UpdateInspectionDefectCapturingCommand : IRequest<Response<int>>
    {
        public int Minor { get; set; }
		public int Major { get; set; }
		public int Critial { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public int Id { get; set; }
        public int QCDefectId { get; set; }
        public int InspectionId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateInspectionDefectCapturingCommandHandler : IRequestHandler<UpdateInspectionDefectCapturingCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturingRepository _repository;
        public UpdateInspectionDefectCapturingCommandHandler(IInspectionDefectCapturingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionDefectCapturingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionDefectCapturing Not Found.");
            entity.IsActive = command.IsActive;
            entity.Minor = command.Minor;
			entity.Major = command.Major;
			entity.Critial = command.Critial;
			entity.ProblemRootCauseId = command.ProblemRootCauseId;
			entity.ProblemCorrectiveActionId = command.ProblemCorrectiveActionId;
			entity.ProblemTimelineId = command.ProblemTimelineId;
			entity.PersonInChargeId = command.PersonInChargeId;
            entity.InspectionId = command.InspectionId;
            entity.QCDefectId = command.QCDefectId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
