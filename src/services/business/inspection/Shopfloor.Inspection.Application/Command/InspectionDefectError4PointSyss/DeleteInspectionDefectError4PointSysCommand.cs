using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss
{
    public class DeleteInspectionDefectError4PointSysCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionDefectError4PointSysCommandHandler : IRequestHandler<DeleteInspectionDefectError4PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectError4PointSysRepository _repository;
        public DeleteInspectionDefectError4PointSysCommandHandler(IInspectionDefectError4PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionDefectError4PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"InspectionDefectError4PointSys Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
