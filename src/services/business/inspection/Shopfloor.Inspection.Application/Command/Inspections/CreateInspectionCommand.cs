using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.Attachments;
using Shopfloor.Inspection.Application.Command.InspectionBySizes;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.Inspections
{
    public class CreateInspectionCommand : IRequest<Response<int>>
    {
        public DateTime InspectionDate { get; set; }
        public int? QCRequestArticleId { get; set; }
        public bool DefaultResult { get; set; }
        public bool UserResult { get; set; }
        public bool MeasurementResult { get; set; }
        public decimal? MeasurementQty { get; set; }
        public decimal? InspectionQty { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
        public string Line { get; set; }
        public decimal TotalDefect { get; set; }
        public string Stage { get; set; }
        public string CuttingTable { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public ICollection<CreateInspectionBySizeCommand> InspectionBySizes { get; set; }
        public ICollection<CreateInspectionMesurementCommand> InspectionMesurements { get; set; }
        public ICollection<CreateInspectionDefectCapturingCommand> InspectionDefectCapturings { get; set; }
        public ICollection<CreateAttachmentCommand> Attachments { get; set; }

    }
    public class CreateInspectionCommandHandler : IRequestHandler<CreateInspectionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionRepository _repository;
        public CreateInspectionCommandHandler(IMapper mapper,
            IInspectionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Shopfloor.Inspection.Domain.Entities.Inspection>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
