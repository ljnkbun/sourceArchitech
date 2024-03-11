using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.OrderEfficiencies
{
    public class DeleteOrderEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteOrderEfficiencyCommandHandler : IRequestHandler<DeleteOrderEfficiencyCommand, Response<int>>
    {
        private readonly IOrderEfficiencyRepository _repository;
        public DeleteOrderEfficiencyCommandHandler(IOrderEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteOrderEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"OrderEfficiency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
