using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionMesurements
{
    public class CreateInspectionMesurementCommand : IRequest<Response<int>>
    {
        public int Minor { get; set; }
		public int Major { get; set; }
		public int Critial { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public int QCDefectId { get; set; }
        public int InspectionId { get; set; }
    }
    public class CreateInspectionMesurementCommandHandler : IRequestHandler<CreateInspectionMesurementCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionMesurementRepository _repository;
        public CreateInspectionMesurementCommandHandler(IMapper mapper,
            IInspectionMesurementRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionMesurementCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionMesurement>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
