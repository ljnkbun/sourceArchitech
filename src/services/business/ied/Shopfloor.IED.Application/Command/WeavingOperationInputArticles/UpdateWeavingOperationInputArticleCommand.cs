using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingOperationInputArticles
{
    public class UpdateWeavingOperationInputArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WeavingOperationId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool IsActive { set; get; }
    }

    public class UpdateWeavingOperationInputArticleCommandHandler : IRequestHandler<UpdateWeavingOperationInputArticleCommand, Response<int>>
    {
        private readonly IWeavingOperationInputArticleRepository _repository;

        public UpdateWeavingOperationInputArticleCommandHandler(IWeavingOperationInputArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateWeavingOperationInputArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingOperationInputArticle Not Found.");

            entity.WeavingOperationId = command.WeavingOperationId;
            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}