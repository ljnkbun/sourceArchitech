using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingTaskLibs
{
    public class DeleteSewingTaskLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingTaskLibCommandHandler : IRequestHandler<DeleteSewingTaskLibCommand, Response<int>>
    {
        private readonly ISewingTaskLibRepository _repository;
        public DeleteSewingTaskLibCommandHandler(ISewingTaskLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingTaskLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingTaskLib Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
