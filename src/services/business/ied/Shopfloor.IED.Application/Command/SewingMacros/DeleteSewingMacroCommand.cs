using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMacros
{
    public class DeleteSewingMacroCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingMacroCommandHandler : IRequestHandler<DeleteSewingMacroCommand, Response<int>>
    {
        private readonly ISewingMacroRepository _repository;
        public DeleteSewingMacroCommandHandler(ISewingMacroRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingMacroCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingMacro Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
