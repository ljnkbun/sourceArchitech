using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Patterns
{
    public class DeletePatternCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePatternCommandHandler : IRequestHandler<DeletePatternCommand, Response<int>>
    {
        private readonly IPatternRepository _repository;
        public DeletePatternCommandHandler(IPatternRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeletePatternCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Pattern Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
