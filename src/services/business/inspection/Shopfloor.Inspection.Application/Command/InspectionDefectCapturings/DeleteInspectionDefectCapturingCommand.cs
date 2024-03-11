using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturings
{
    public class DeleteInspectionDefectCapturingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionDefectCapturingCommandHandler : IRequestHandler<DeleteInspectionDefectCapturingCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturingRepository _repository;
        public DeleteInspectionDefectCapturingCommandHandler(IInspectionDefectCapturingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionDefectCapturingCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"InspectionDefectCapturing Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
