using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionMesurements
{
    public class UpdateInspectionMesurementCommand : IRequest<Response<int>>
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
        public bool IsActive { set; get; }
        public int InspectionId { get; set; }
    }
    public class UpdateInspectionMesurementCommandHandler : IRequestHandler<UpdateInspectionMesurementCommand, Response<int>>
    {
        private readonly IInspectionMesurementRepository _repository;
        public UpdateInspectionMesurementCommandHandler(IInspectionMesurementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionMesurementCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionMesurement Not Found.");
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
