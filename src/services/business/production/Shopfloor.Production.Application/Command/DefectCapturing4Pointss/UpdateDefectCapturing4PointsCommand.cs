using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturing4Pointss
{
    public class UpdateDefectCapturing4PointsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }

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
    public class UpdateDefectCapturing4PointsCommandHandler : IRequestHandler<UpdateDefectCapturing4PointsCommand, Response<int>>
    {
        private readonly IDefectCapturing4PointsRepository _repository;
        public UpdateDefectCapturing4PointsCommandHandler(IDefectCapturing4PointsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateDefectCapturing4PointsCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DefectCapturing4Points Not Found.");

            entity.ProductionOutputId = command.ProductionOutputId;
            entity.QCDefectId = command.QCDefectId;
            entity.MinorOne = command.MinorOne;
            entity.MinorTwo = command.MinorTwo;
            entity.MinorThree = command.MinorThree;
            entity.MinorFour = command.MinorFour;
            entity.MajorOne = command.MajorOne;
            entity.MajorTwo = command.MajorTwo;
            entity.MajorThree = command.MajorThree;
            entity.MajorFour = command.MajorFour;
            entity.DefectQtyOne = command.DefectQtyOne;
            entity.DefectQtyTwo = command.DefectQtyTwo;
            entity.DefectQtyThree = command.DefectQtyThree;
            entity.DefectQtyFour = command.DefectQtyFour;
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
