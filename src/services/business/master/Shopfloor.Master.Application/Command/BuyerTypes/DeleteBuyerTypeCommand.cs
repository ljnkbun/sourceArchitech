using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.BuyerTypes
{
    public class DeleteBuyerTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteBuyerTypeCommandHandler : IRequestHandler<DeleteBuyerTypeCommand, Response<int>>
    {
        private readonly IBuyerTypeRepository _repository;
        public DeleteBuyerTypeCommandHandler(IBuyerTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteBuyerTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"BuyerType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
