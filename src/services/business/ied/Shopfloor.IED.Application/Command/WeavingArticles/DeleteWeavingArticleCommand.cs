using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingArticles
{
    public class DeleteWeavingArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingArticleCommandHandler : IRequestHandler<DeleteWeavingArticleCommand, Response<int>>
    {
        private readonly IWeavingArticleRepository _repository;
        public DeleteWeavingArticleCommandHandler(IWeavingArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"WeavingArticle Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
