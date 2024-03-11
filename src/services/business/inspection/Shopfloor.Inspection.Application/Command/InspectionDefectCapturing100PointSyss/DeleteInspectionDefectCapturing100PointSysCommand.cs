using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss
{
    public class DeleteInspectionDefectCapturing100PointSysCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionDefectCapturing100PointSysCommandHandler : IRequestHandler<DeleteInspectionDefectCapturing100PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturing100PointSysRepository _repository;
        public DeleteInspectionDefectCapturing100PointSysCommandHandler(IInspectionDefectCapturing100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionDefectCapturing100PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"InspectionDefectCapturing100PointSys Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
