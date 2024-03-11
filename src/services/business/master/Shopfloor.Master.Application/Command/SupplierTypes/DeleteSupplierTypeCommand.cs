using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SupplierTypes
{
    public class DeleteSupplierTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSupplierTypeCommandHandler : IRequestHandler<DeleteSupplierTypeCommand, Response<int>>
    {
        private readonly ISupplierTypeRepository _repository;
        public DeleteSupplierTypeCommandHandler(ISupplierTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSupplierTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SupplierType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
