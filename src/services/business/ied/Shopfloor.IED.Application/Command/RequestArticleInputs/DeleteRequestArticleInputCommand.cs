using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleInputs
{
    public class DeleteRequestArticleInputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestArticleInputCommandHandler : IRequestHandler<DeleteRequestArticleInputCommand, Response<int>>
    {
        private readonly IRequestArticleInputRepository _repository;
        public DeleteRequestArticleInputCommandHandler(IRequestArticleInputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestArticleInputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"RequestArticleInput Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
