using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards
{
    public class DeleteInspectionDefectCapturingTCStandardCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionDefectCapturingTCStandardCommandHandler : IRequestHandler<DeleteInspectionDefectCapturingTCStandardCommand, Response<int>>
    {
        private readonly IInspectionDefectCapturingTCStandardRepository _repository;
        public DeleteInspectionDefectCapturingTCStandardCommandHandler(IInspectionDefectCapturingTCStandardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionDefectCapturingTCStandardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"InspectionDefectCapturingTCStandard Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
