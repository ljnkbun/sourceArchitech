using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss
{
    public class CreateInspectionDefectCapturing100PointSysCommand : IRequest<Response<int>>
    {
        public int Inpection100PointSysId { get; set; }
        public int QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critial { get; set; }
        public int? AttachmentId { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public ICollection<CreateInspectionDefectError100PointSysCommand> InspectionDefectError100PointSyss { get; set; }
    }
    public class CreateInspectionDefectCapturing100PointSysCommandHandler : IRequestHandler<CreateInspectionDefectCapturing100PointSysCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturing100PointSysRepository _repository;
        public CreateInspectionDefectCapturing100PointSysCommandHandler(IMapper mapper,
            IInspectionDefectCapturing100PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionDefectCapturing100PointSysCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionDefectCapturing100PointSys>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
