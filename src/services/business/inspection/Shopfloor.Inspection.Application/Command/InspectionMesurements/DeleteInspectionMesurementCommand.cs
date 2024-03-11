using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.InspectionMesurements
{
    public class DeleteInspectionMesurementCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionMesurementCommandHandler : IRequestHandler<DeleteInspectionMesurementCommand, Response<int>>
    {
        private readonly IInspectionMesurementRepository _repository;
        public DeleteInspectionMesurementCommandHandler(IInspectionMesurementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionMesurementCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"InspectionMesurement Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
