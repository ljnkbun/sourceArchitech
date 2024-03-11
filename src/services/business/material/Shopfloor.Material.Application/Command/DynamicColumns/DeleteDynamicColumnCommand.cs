using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.DynamicColumns
{
    public class DeleteDynamicColumnCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDynamicColumnCommandHandler : IRequestHandler<DeleteDynamicColumnCommand, Response<int>>
    {
        private readonly IDynamicColumnRepository _repository;

        public DeleteDynamicColumnCommandHandler(IDynamicColumnRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDynamicColumnCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DynamicColumn Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}