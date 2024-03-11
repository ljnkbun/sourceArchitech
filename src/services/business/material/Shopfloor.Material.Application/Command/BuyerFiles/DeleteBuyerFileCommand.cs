using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.BuyerFiles
{
    public class DeleteBuyerFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBuyerFileCommandHandler : IRequestHandler<DeleteBuyerFileCommand, Response<int>>
    {
        private readonly IBuyerFileRepository _repository;

        public DeleteBuyerFileCommandHandler(IBuyerFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteBuyerFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"BuyerFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}