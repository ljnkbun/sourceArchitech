using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss
{
    public class UpdateInspectionDefectError100PointSysCommand : IRequest<Response<int>>
    {
        public int InspectionDefectCapturing100PointSysId { get; set; }
		public ErrorType ErrorType { get; set; }
		public decimal From { get; set; }
		public decimal? To { get; set; }
        public int Id { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateInspectionDefectError100PointSysCommandHandler : IRequestHandler<UpdateInspectionDefectError100PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectError100PointSysRepository _repository;
        public UpdateInspectionDefectError100PointSysCommandHandler(IInspectionDefectError100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionDefectError100PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionDefectError100PointSys Not Found.");
            entity.IsActive = command.IsActive;
            entity.InspectionDefectCapturing100PointSysId = command.InspectionDefectCapturing100PointSysId;
            entity.ErrorType = command.ErrorType;
            entity.From = command.From;
            entity.To = command.To;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
