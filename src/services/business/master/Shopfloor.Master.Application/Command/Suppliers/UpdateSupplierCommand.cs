using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Suppliers
{
    public class UpdateSupplierCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string WFXSupplierId { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Response<int>>
    {
        private readonly ISupplierRepository _repository;

        public UpdateSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateSupplierCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Suppliers Not Found.");

            entity.WFXSupplierId = command.WFXSupplierId;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}