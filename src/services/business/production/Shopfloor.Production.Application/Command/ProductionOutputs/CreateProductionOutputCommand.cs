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
    public class CreateProductionOutputCommand : IRequest<Response<int>>
    {
        public int? QCDefinitionId { get; set; }
        public int? FPPOOutputId { get; set; }
        public int? AttachmentId { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? WFXExportDate { get; set; }
        public WFXExportStatus? WFXExportStatus { get; set; }
        public SaveStatus? Status { get; set; }

        public ICollection<CreateInspectionBySizeCommand> InspectionBySizes { get; set; }
        public ICollection<CreateDefectCapturingCommand> DefectCapturings { get; set; }
        public ICollection<CreateDefectCapturing4PointsCommand> DefectCapturing4Pointss { get; set; }
        public ICollection<CreateDefectCapturing100PointsCommand> DefectCapturing100Pointss { get; set; }
        public ICollection<CreateDefectCapturingStandardCommand> DefectCapturingStandards { get; set; }
        public ICollection<CreateMeasurementCommand> Measurements { get; set; }
    }
    public class CreateProductionOutputCommandHandler : IRequestHandler<CreateProductionOutputCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProductionOutputRepository _repository;
        public CreateProductionOutputCommandHandler(IMapper mapper,
            IProductionOutputRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductionOutputCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductionOutput>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
