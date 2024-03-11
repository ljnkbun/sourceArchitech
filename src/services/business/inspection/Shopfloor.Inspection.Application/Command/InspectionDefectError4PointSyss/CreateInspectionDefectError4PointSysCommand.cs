using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss
{
    public class CreateInspectionDefectError4PointSysCommand : IRequest<Response<int>>
    {
        public int InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType ErrorType { get; set; }
		public decimal From { get; set; }
		public decimal? To { get; set; }
    }
    public class CreateInspectionDefectError4PointSysCommandHandler : IRequestHandler<CreateInspectionDefectError4PointSysCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectError4PointSysRepository _repository;
        public CreateInspectionDefectError4PointSysCommandHandler(IMapper mapper,
            IInspectionDefectError4PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionDefectError4PointSysCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionDefectError4PointSys>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
