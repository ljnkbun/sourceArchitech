﻿using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class DeleteSupplierCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Response<int>>
    {
        private readonly ISupplierRepository _repository;

        public DeleteSupplierCommandHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteSupplierCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Supplier Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}