using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingIEDs
{
    public class UpdateKnittingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Buyer { get; set; }
        public string Remark { get; set; }
        public Status Status { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingIEDCommandHandler : IRequestHandler<UpdateKnittingIEDCommand, Response<int>>
    {
        private readonly IKnittingIEDRepository _repository;
        public UpdateKnittingIEDCommandHandler(IKnittingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingIED Not Found.");

            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.ProductGroup = command.ProductGroup;
            entity.SubCategory = command.SubCategory;
            entity.Buyer = command.Buyer;
            entity.Remark = command.Remark;
            entity.Status = command.Status;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
