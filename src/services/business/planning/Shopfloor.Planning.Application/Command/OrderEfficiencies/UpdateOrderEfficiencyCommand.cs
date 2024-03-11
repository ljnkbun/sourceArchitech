using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.OrderEfficiencies
{
    public class UpdateOrderEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string OCNo { get; set; }
        public decimal EfficiencyValue { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateOrderEfficiencyCommandHandler : IRequestHandler<UpdateOrderEfficiencyCommand, Response<int>>
    {
        private readonly IOrderEfficiencyRepository _repository;

        public UpdateOrderEfficiencyCommandHandler(IOrderEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateOrderEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"OrderEfficiency Not Found.");

            entity.OCNo = command.OCNo;
            entity.EfficiencyValue = command.EfficiencyValue;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
