using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMacroLibs
{
    public class DeleteSewingMacroLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingMacroLibCommandHandler : IRequestHandler<DeleteSewingMacroLibCommand, Response<int>>
    {
        private readonly ISewingMacroLibRepository _repository;
        public DeleteSewingMacroLibCommandHandler(ISewingMacroLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingMacroLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingMacroLib Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
