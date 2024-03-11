using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.AccountGroups
{
    public class DeleteAccountGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteAccountGroupCommandHandler : IRequestHandler<DeleteAccountGroupCommand, Response<int>>
    {
        private readonly IAccountGroupRepository _repository;
        public DeleteAccountGroupCommandHandler(IAccountGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteAccountGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"AccountGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
