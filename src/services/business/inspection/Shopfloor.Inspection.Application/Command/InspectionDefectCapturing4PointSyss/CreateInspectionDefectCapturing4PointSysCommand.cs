using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss
{
    public class CreateInspectionDefectCapturing4PointSysCommand : IRequest<Response<int>>
    {
        public int Inpection4PointSysId { get; set; }
        public int QCDefectId { get; set; }
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
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public ICollection<CreateInspectionDefectError4PointSysCommand> InspectionDefectError4PointSyss { get; set; }
    }
    public class CreateInspectionDefectCapturing4PointSysCommandHandler : IRequestHandler<CreateInspectionDefectCapturing4PointSysCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectCapturing4PointSysRepository _repository;
        public CreateInspectionDefectCapturing4PointSysCommandHandler(IMapper mapper,
            IInspectionDefectCapturing4PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionDefectCapturing4PointSysCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionDefectCapturing4PointSys>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
