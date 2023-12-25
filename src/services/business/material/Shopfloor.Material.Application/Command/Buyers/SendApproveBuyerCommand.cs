using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class SendApproveBuyerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SendApproveBuyerCommandHandler : IRequestHandler<SendApproveBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public SendApproveBuyerCommandHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SendApproveBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"{typeof(Buyer).Name} Not Found (Id:{command.Id}).");
            entity.Status = Domain.Enums.ProcessStatus.Confirmed;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}