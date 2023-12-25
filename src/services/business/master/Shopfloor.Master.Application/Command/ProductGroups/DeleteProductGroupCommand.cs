using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroups
{
    public class DeleteProductGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, Response<int>>
    {
        private readonly IProductGroupRepository _repository;
        public DeleteProductGroupCommandHandler(IProductGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProductGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ProductGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
