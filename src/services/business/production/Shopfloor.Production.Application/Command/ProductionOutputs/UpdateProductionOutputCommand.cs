using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Command.DefectCapturing100Pointss;
using Shopfloor.Production.Application.Command.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Command.DefectCapturings;
using Shopfloor.Production.Application.Command.DefectCapturingStandards;
using Shopfloor.Production.Application.Command.InspectionBySizes;
using Shopfloor.Production.Application.Command.Measurements;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Enums;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.ProductionOutputs
{
    public class UpdateProductionOutputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? QCDefinitionId { get; set; }
        public int? FPPOOutputId { get; set; }
        public int? AttachmentId { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? WFXExportDate { get; set; }
        public WFXExportStatus? WFXExportStatus { get; set; }
        public SaveStatus? Status { get; set; } = SaveStatus.Draft;


        public ICollection<UpdateInspectionBySizeCommand> InspectionBySizes { get; set; }
        public ICollection<UpdateDefectCapturingCommand> DefectCapturings { get; set; }
        public ICollection<UpdateDefectCapturing4PointsCommand> DefectCapturing4Pointss { get; set; }
        public ICollection<UpdateDefectCapturing100PointsCommand> DefectCapturing100Pointss { get; set; }
        public ICollection<UpdateDefectCapturingStandardCommand> DefectCapturingStandards { get; set; }
        public ICollection<UpdateMeasurementCommand> Measurements { get; set; }
    }
    public class UpdateProductionOutputCommandHandler : IRequestHandler<UpdateProductionOutputCommand, Response<int>>
    {
        private readonly IProductionOutputRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductionOutputCommandHandler(IProductionOutputRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateProductionOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ProductionOutput Not Found.");

            var dbBySize = entity.InspectionBySizes;
            var newBySize = command.InspectionBySizes;
            var dbMesurement = entity.Measurements;
            var newMesurement = command.Measurements;
            var dbDefectCapturing = entity.DefectCapturings;
            var newDefectCapturing = command.DefectCapturings;
            var dbDefectCapturing4Points = entity.DefectCapturing4Points;
            var newDefectCapturing4Points = command.DefectCapturing4Pointss;
            var dbDefectCapturing100Points = entity.DefectCapturing100Points;
            var newDefectCapturing100Points = command.DefectCapturing100Pointss;

            entity.QCDefinitionId = command.QCDefinitionId;
            entity.AttachmentId = command.AttachmentId;
            entity.WFXExportDate = command.WFXExportDate;
            entity.Code = command.Code;
            entity.FPPOOutputId = command.FPPOOutputId;
            entity.Remarks = command.Remarks;
            entity.WFXExportStatus = command.WFXExportStatus;
            entity.InputDate = command.InputDate;
            entity.Status = command.Status;

            var dbBySizeModifieds = dbBySize.Where(x => newBySize.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<InspectionBySize>(newBySize.FirstOrDefault(c => c.Id == x.Id)));
            var dbMesurementModifieds = dbMesurement.Where(x => newMesurement.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<Measurement>(newMesurement.FirstOrDefault(c => c.Id == x.Id)));
            var dbDefectCapturingModifieds = dbDefectCapturing.Where(x => newDefectCapturing.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<DefectCapturing>(newDefectCapturing.FirstOrDefault(c => c.Id == x.Id)));
            var dbDefectCapturing4PointsModifieds = dbDefectCapturing4Points.Where(x => newDefectCapturing4Points.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<DefectCapturing4Points>(newDefectCapturing4Points.FirstOrDefault(c => c.Id == x.Id)));
            var dbDefectCapturing100PointsModifieds = dbDefectCapturing100Points.Where(x => newDefectCapturing100Points.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<DefectCapturing100Points>(newDefectCapturing100Points.FirstOrDefault(c => c.Id == x.Id)));


            await _repository.UpdateProductionOuputAsync(entity, dbBySizeModifieds, dbMesurementModifieds, dbDefectCapturingModifieds, dbDefectCapturing4PointsModifieds, dbDefectCapturing100PointsModifieds);

            return new Response<int>(entity.Id);
        }
    }
}
