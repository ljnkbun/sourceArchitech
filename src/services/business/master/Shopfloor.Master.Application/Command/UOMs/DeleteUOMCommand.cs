using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMs
{
    public class DeleteUOMCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteUOMCommandHandler : IRequestHandler<DeleteUOMCommand, Response<int>>
    {
        private readonly IUOMRepository _repository;
        public DeleteUOMCommandHandler(IUOMRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteUOMCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"UOM Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
