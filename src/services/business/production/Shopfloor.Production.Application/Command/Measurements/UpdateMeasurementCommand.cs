using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.Measurements
{
    public class UpdateMeasurementCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critical { get; set; }
        public int? ParentId { get; set; }
        public string RootCauseIds { get; set; }
        public string PersonInChargeIds { get; set; }
        public string CorrectActionIds { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorName { get; set; }
        public string RootCauseName { get; set; }
        public string PersonInChargeName { get; set; }
        public string CorrectActionName { get; set; }

        public int? TimelineId { get; set; }
    }
    public class UpdateMeasurementCommandHandler : IRequestHandler<UpdateMeasurementCommand, Response<int>>
    {
        private readonly IMeasurementRepository _repository;
        public UpdateMeasurementCommandHandler(IMeasurementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateMeasurementCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Measurement Not Found.");

            entity.ProductionOutputId = command.ProductionOutputId;
            entity.QCDefectId = command.QCDefectId;
            entity.Minor = command.Minor;
            entity.Major = command.Major;
            entity.Critical = command.Critical;
            entity.ParentId = command.ParentId;
            entity.RootCauseIds = command.RootCauseIds;
            entity.PersonInChargeIds = command.PersonInChargeIds;
            entity.CorrectActionIds = command.CorrectActionIds;
            entity.ErrorCode = command.ErrorCode;
            entity.ErrorName = command.ErrorName;
            entity.TimelineId = command.TimelineId;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
