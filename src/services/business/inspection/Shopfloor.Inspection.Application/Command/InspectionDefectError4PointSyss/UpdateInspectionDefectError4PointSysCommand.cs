using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss
{
    public class UpdateInspectionDefectError4PointSysCommand : IRequest<Response<int>>
    {
        public int InspectionDefectCapturing4PointSysId { get; set; }
		public ErrorType ErrorType { get; set; }
		public decimal From { get; set; }
		public decimal? To { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateInspectionDefectError4PointSysCommandHandler : IRequestHandler<UpdateInspectionDefectError4PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectError4PointSysRepository _repository;
        public UpdateInspectionDefectError4PointSysCommandHandler(IInspectionDefectError4PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionDefectError4PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionDefectError4PointSys Not Found.");
            entity.IsActive = command.IsActive;
            entity.InspectionDefectCapturing4PointSysId = command.InspectionDefectCapturing4PointSysId;
			entity.ErrorType = command.ErrorType;
			entity.From = command.From;
			entity.To = command.To;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
