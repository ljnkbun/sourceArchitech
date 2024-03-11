using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingComponentGroups
{
    public class DeleteSewingComponentGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingComponentGroupCommandHandler : IRequestHandler<DeleteSewingComponentGroupCommand, Response<int>>
    {
        private readonly ISewingComponentGroupRepository _repository;
        public DeleteSewingComponentGroupCommandHandler(ISewingComponentGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingComponentGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingComponentGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
