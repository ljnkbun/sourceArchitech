using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CountTypes
{
    public class DeleteCountTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCountTypeCommandHandler : IRequestHandler<DeleteCountTypeCommand, Response<int>>
    {
        private readonly ICountTypeRepository _repository;
        public DeleteCountTypeCommandHandler(ICountTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCountTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"CountType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
