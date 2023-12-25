using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Gauges
{
    public class DeleteGaugeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteGaugeCommandHandler : IRequestHandler<DeleteGaugeCommand, Response<int>>
    {
        private readonly IGaugeRepository _repository;
        public DeleteGaugeCommandHandler(IGaugeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteGaugeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Gauge Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
