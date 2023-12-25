using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.YarnCompositions
{
    public class DeleteYarnCompositionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteYarnCompositionCommandHandler : IRequestHandler<DeleteYarnCompositionCommand, Response<int>>
    {
        private readonly IYarnCompositionRepository _repository;
        public DeleteYarnCompositionCommandHandler(IYarnCompositionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteYarnCompositionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"YarnComposition Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
