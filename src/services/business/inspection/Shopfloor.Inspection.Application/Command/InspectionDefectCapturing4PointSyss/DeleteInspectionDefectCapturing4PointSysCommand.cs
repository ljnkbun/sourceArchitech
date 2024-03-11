using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss
{
    public class DeleteInspectionDefectCapturing4PointSysCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionDefectCapturing4PointSysCommandHandler : IRequestHandler<DeleteInspectionDefectCapturing4PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturing4PointSysRepository _repository;
        public DeleteInspectionDefectCapturing4PointSysCommandHandler(IInspectionDefectCapturing4PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionDefectCapturing4PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"InspectionDefectCapturing4PointSys Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
