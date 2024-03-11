using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCRequestArticles
{
    public class DeleteQCRequestArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCRequestArticleCommandHandler : IRequestHandler<DeleteQCRequestArticleCommand, Response<int>>
    {
        private readonly IQCRequestArticleRepository _repository;
        public DeleteQCRequestArticleCommandHandler(IQCRequestArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCRequestArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"QCRequestArticle Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
