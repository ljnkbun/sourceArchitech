using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Buyers
{
    public class DeleteBuyerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBuyerCommandHandler : IRequestHandler<DeleteBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public DeleteBuyerCommandHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Buyer Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}