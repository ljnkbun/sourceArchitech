using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.ProductionOutputs
{
    public class DeleteProductionOutputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteProductionOutputCommandHandler : IRequestHandler<DeleteProductionOutputCommand, Response<int>>
    {
        private readonly IProductionOutputRepository _repository;
        public DeleteProductionOutputCommandHandler(IProductionOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteProductionOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ProductionOutput Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
