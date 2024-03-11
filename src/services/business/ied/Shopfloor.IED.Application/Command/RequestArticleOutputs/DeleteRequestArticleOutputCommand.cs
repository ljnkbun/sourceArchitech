using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class DeleteRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestArticleOutputCommandHandler : IRequestHandler<DeleteRequestArticleOutputCommand, Response<int>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public DeleteRequestArticleOutputCommandHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestArticleOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"RequestArticleOutput Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
