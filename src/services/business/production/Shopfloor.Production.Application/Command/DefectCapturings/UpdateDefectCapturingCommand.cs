using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturings
{
    public class UpdateDefectCapturingCommand : IRequest<Response<int>>
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
        public bool? IsLongError { get; set; }
        public decimal? LongErrorFrom { get; set; }
        public decimal? LongErrorTo { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorName { get; set; }
        public string RootCauseName { get; set; }
        public string PersonInChargeName { get; set; }
        public string CorrectActionName { get; set; }

        public int? TimelineId { get; set; }
    }
    public class UpdateDefectCapturingCommandHandler : IRequestHandler<UpdateDefectCapturingCommand, Response<int>>
    {
        private readonly IDefectCapturingRepository _repository;
        public UpdateDefectCapturingCommandHandler(IDefectCapturingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateDefectCapturingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DefectCapturing Not Found.");

            entity.ProductionOutputId = command.ProductionOutputId;
            entity.QCDefectId = command.QCDefectId;
            entity.Minor = command.Minor;
            entity.Major = command.Major;
            entity.Critical = command.Critical;
            entity.ParentId = command.ParentId;
            entity.RootCauseIds = command.RootCauseIds;
            entity.PersonInChargeIds = command.PersonInChargeIds;
            entity.CorrectActionIds = command.CorrectActionIds;
            entity.IsLongError = command.IsLongError;
            entity.LongErrorFrom = command.LongErrorFrom;
            entity.LongErrorTo = command.LongErrorTo;
            entity.ErrorCode = command.ErrorCode;
            entity.ErrorName = command.ErrorName;
            entity.RootCauseName = command.RootCauseName;
            entity.PersonInChargeName = command.PersonInChargeName;
            entity.CorrectActionName = command.CorrectActionName;
            entity.TimelineId = command.TimelineId;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
