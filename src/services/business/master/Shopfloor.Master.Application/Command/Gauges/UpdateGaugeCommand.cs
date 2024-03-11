using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Gauges
{
    public class UpdateGaugeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateGaugeCommandHandler : IRequestHandler<UpdateGaugeCommand, Response<int>>
    {
        private readonly IGaugeRepository _repository;
        public UpdateGaugeCommandHandler(IGaugeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateGaugeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Gauge Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
