using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroupUOMs
{
    public class UpdateProductGroupUOMCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int UOMId { get; set; }
        public int ProductGroupId { get; set; }
        public bool IsActive { set; get; }
    }

    public class UpdateProductGroupUOMCommandHandler : IRequestHandler<UpdateProductGroupUOMCommand, Response<int>>
    {
        private readonly IProductGroupUOMRepository _repository;

        public UpdateProductGroupUOMCommandHandler(IProductGroupUOMRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateProductGroupUOMCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ProductGroupUOM Not Found.");

            entity.ProductGroupId = command.ProductGroupId;
            entity.UOMId = command.UOMId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}