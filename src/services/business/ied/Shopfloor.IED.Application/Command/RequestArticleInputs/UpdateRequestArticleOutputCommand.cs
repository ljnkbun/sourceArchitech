using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleInputs
{
    public class UpdateRequestArticleInputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateRequestArticleInputCommandHandler : IRequestHandler<UpdateRequestArticleInputCommand, Response<int>>
    {
        private readonly IRequestArticleInputRepository _repository;
        public UpdateRequestArticleInputCommandHandler(IRequestArticleInputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRequestArticleInputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"RequestArticleInput Not Found.");

            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;  
            entity.ArticleName = command.ArticleName;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
