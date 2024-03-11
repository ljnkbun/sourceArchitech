using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Machines
{
    public class UpdateGaugeByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Gauge { get; set; }
    }

    public class UpdateGaugeByIdCommandHandler : IRequestHandler<UpdateGaugeByIdCommand, Response<int>>
    {
        private readonly IMachineRepository _repository;

        public UpdateGaugeByIdCommandHandler(IMachineRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateGaugeByIdCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Machine Not Found.");

            entity.Gauge = command.Gauge;

           await _repository.UpdateAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
