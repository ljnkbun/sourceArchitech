using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.Measurements
{
    public class DeleteMeasurementCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMeasurementCommandHandler : IRequestHandler<DeleteMeasurementCommand, Response<int>>
    {
        private readonly IMeasurementRepository _repository;
        public DeleteMeasurementCommandHandler(IMeasurementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMeasurementCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Measurement Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
