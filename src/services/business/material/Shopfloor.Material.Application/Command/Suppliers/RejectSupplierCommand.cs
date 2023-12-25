using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class RejectSupplierCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string ReasonReject { get; set; }
    }

    public class RejectSupplierCommandHandler : IRequestHandler<RejectSupplierCommand, Response<int>>
    {
        private readonly ISupplierRepository _repository;

        public RejectSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(RejectSupplierCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Supplier Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Rejected;
            entity.ReasonReject = command.ReasonReject;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}