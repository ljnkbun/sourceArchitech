using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards
{
    public class CreateInspectionDefectCapturingTCStandardCommand : IRequest<Response<int>>
    {
        public int InpectionTCStandardId { get; set; }
		public int QCDefectId { get; set; }
		public int Defect { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
    }
    public class CreateInspectionDefectCapturingTCStandardCommandHandler : IRequestHandler<CreateInspectionDefectCapturingTCStandardCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturingTCStandardRepository _repository;
        public CreateInspectionDefectCapturingTCStandardCommandHandler(IMapper mapper,
            IInspectionDefectCapturingTCStandardRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionDefectCapturingTCStandardCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionDefectCapturingTCStandard>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
