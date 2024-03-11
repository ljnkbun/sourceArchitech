using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.SupplierFiles
{
    public class DeleteSupplierFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupplierFileCommandHandler : IRequestHandler<DeleteSupplierFileCommand, Response<int>>
    {
        private readonly ISupplierFileRepository _repository;

        public DeleteSupplierFileCommandHandler(ISupplierFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteSupplierFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SupplierFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}