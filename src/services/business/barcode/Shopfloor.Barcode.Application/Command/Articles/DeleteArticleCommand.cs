using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Articles
{
    public class DeleteArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Response<int>>
    {
        private readonly IArticleRepository _repository;
        public DeleteArticleCommandHandler(IArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Article Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
