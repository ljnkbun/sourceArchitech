using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Lines
{
    public class DeleteLineCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLineCommandHandler : IRequestHandler<DeleteLineCommand, Response<int>>
    {
        private readonly ILineRepository _repository;
        public DeleteLineCommandHandler(ILineRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLineCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Line Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
