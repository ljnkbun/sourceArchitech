using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss
{
    public class CreateInspectionDefectError100PointSysCommand : IRequest<Response<int>>
    {
        public int InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType ErrorType { get; set; }
		public decimal From { get; set; }
		public decimal? To { get; set; }
    }
    public class CreateInspectionDefectError100PointSysCommandHandler : IRequestHandler<CreateInspectionDefectError100PointSysCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionDefectError100PointSysRepository _repository;
        public CreateInspectionDefectError100PointSysCommandHandler(IMapper mapper,
            IInspectionDefectError100PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInspectionDefectError100PointSysCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InspectionDefectError100PointSys>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
