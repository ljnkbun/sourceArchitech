using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss
{
    public class DeleteInspectionDefectError100PointSysCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionDefectError100PointSysCommandHandler : IRequestHandler<DeleteInspectionDefectError100PointSysCommand, Response<int>>
    {
        private readonly IInspectionDefectError100PointSysRepository _repository;
        public DeleteInspectionDefectError100PointSysCommandHandler(IInspectionDefectError100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionDefectError100PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"InspectionDefectError100PointSys Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
