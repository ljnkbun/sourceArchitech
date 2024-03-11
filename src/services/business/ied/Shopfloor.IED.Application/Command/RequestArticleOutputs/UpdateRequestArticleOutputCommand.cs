using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RequestArticleInputs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class UpdateRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string BaseColorList { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateRequestArticleInputCommand> RequestArticleInputs { get; set; }
    }
    public class UpdateRequestArticleOutputCommandHandler : IRequestHandler<UpdateRequestArticleOutputCommand, Response<int>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public UpdateRequestArticleOutputCommandHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRequestArticleOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"RequestArticleOutput Not Found.");

            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;  
            entity.ArticleName = command.ArticleName;
            entity.Color = command.Color;
            entity.BaseColorList = command.BaseColorList;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
