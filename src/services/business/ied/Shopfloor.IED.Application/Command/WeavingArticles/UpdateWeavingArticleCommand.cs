using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingArticles
{
    public class UpdateWeavingArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingArticleCommandHandler : IRequestHandler<UpdateWeavingArticleCommand, Response<int>>
    {
        private readonly IWeavingArticleRepository _repository;
        public UpdateWeavingArticleCommandHandler(IWeavingArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingArticle Not Found.");

            entity.ArticleId = command.ArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
