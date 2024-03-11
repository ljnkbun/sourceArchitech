using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Buyers
{
    public class UpdateBuyerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string WFXBuyerId { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }

    public class UpdateBuyerCommandHandler : IRequestHandler<UpdateBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public UpdateBuyerCommandHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Buyers Not Found.");

            entity.WFXBuyerId = command.WFXBuyerId;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}