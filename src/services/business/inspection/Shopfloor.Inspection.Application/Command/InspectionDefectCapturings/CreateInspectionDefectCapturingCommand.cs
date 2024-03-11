using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturings
{
    public class CreateInspectionDefectCapturingCommand : IRequest<Response<int>>
    {
        public int Minor { get; set; }
		public int Major { get; set; }
		public int Critial { get; set; }
        public int QCDefectId { get; set; }
        public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public int InspectionId { get; set; }
    }
    public class CreateInspectionDefectCapturingCommandHandler : IRequestHandler<CreateInspectionDefectCapturingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturingRepository _repository;
        public CreateInspectionDefectCapturingCommandHandler(IMapper mapper,
            IInspectionDefectCapturingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionDefectCapturingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionDefectCapturing>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
