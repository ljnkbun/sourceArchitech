using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class ApproveSupplierCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class ApproveSupplierCommandHandler : IRequestHandler<ApproveSupplierCommand, Response<int>>
    {
        private readonly ISupplierRepository _repository;

        public ApproveSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(ApproveSupplierCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Supplier Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Approved;
            entity.ReasonReject = null;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}