using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingOperationInputArticles
{
    public class DeleteWeavingOperationInputArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWeavingOperationInputArticleCommandHandler : IRequestHandler<DeleteWeavingOperationInputArticleCommand, Response<int>>
    {
        private readonly IWeavingOperationInputArticleRepository _repository;

        public DeleteWeavingOperationInputArticleCommandHandler(IWeavingOperationInputArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteWeavingOperationInputArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingOperationInputArticle Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}