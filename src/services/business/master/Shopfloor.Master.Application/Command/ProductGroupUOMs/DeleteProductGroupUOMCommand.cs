using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroupUOMs
{
    public class DeleteProductGroupUOMCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteProductGroupUOMCommandHandler : IRequestHandler<DeleteProductGroupUOMCommand, Response<int>>
    {
        private readonly IProductGroupUOMRepository _repository;

        public DeleteProductGroupUOMCommandHandler(IProductGroupUOMRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteProductGroupUOMCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ProductGroupUOM Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}