using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class SendApproveSupplierCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SendApproveSupplierCommandHandler : IRequestHandler<SendApproveSupplierCommand, Response<int>>
    {
        private readonly ISupplierRepository _repository;

        public SendApproveSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SendApproveSupplierCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Supplier Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Confirmed;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}