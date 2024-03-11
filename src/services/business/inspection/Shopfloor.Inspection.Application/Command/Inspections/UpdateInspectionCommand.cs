using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionBySizes;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturings;
using AutoMapper;
using Shopfloor.Inspection.Application.Models.Inspections;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Command.Inspections
{
    public class UpdateInspectionCommand : IRequest<Response<int>>
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
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
        public ICollection<UpdateInspectionBySizeCommand> InspectionBySizes { get; set; }
        public ICollection<UpdateInspectionMesurementCommand> InspectionMesurements { get; set; }
        public ICollection<UpdateInspectionDefectCapturingCommand> InspectionDefectCapturings { get; set; }
    }
    public class UpdateInspectionCommandHandler : IRequestHandler<UpdateInspectionCommand, Response<int>>
    {
        private readonly IInspectionRepository _repository;
        private readonly IMapper _mapper;
        public UpdateInspectionCommandHandler(IMapper mapper,IInspectionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateInspectionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetInspectionByIdAsync(command.Id);
            if (entity == null) return new($"Inspection Not Found.");
			var dbInspectionBySize = entity.InspectionBySizes;
			var newInspectionBySize = command.InspectionBySizes;
			var dbInspectionMesurement = entity.InspectionMesurements;
			var newInspectionMesurement = command.InspectionMesurements;
			var dbInspectionDefectCapturing = entity.InspectionDefectCapturings;
			var newInspectionDefectCapturing = command.InspectionDefectCapturings;
			entity.IsActive = command.IsActive;
			entity.InspectionDate = command.InspectionDate;
			entity.DefaultResult = command.DefaultResult;
			entity.UserResult = command.UserResult;
			entity.MeasurementResult = command.MeasurementResult;
			entity.MeasurementQty = command.MeasurementQty;
			entity.InspectionQty = command.InspectionQty;
			entity.Reason = command.Reason;
			entity.Remark = command.Remark;
			entity.Line = command.Line;
			entity.TotalDefect = command.TotalDefect;
			entity.Stage = command.Stage;
			entity.CuttingTable = command.CuttingTable;
			entity.IsCreatedFromProduction = command.IsCreatedFromProduction;
			var dbInspectionBySizeModifieds = dbInspectionBySize.Where(x => newInspectionBySize.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionBySizeCommand, InspectionBySize>(newInspectionBySize.First(c => c.Id == x.Id), x));
			var dbInspectionMesurementModifieds = dbInspectionMesurement.Where(x => newInspectionMesurement.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionMesurementCommand, InspectionMesurement>(newInspectionMesurement.First(c => c.Id == x.Id), x));
			var dbInspectionDefectCapturingModifieds = dbInspectionDefectCapturing.Where(x => newInspectionDefectCapturing.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionDefectCapturingCommand, InspectionDefectCapturing>(newInspectionDefectCapturing.First(c => c.Id == x.Id), x));
            await _repository.UpdateInspectionAsync(entity,dbInspectionDefectCapturingModifieds,dbInspectionBySizeModifieds,dbInspectionMesurementModifieds);

            return new Response<int>(entity.Id);
        }
    }
}
