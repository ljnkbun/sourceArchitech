using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingIEDs
{
    public class UpdateSewingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Buyer { get; set; }
        public string StyleRef { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal FactoryTime { get; set; }
        public decimal LabourCostOp { get; set; }
        public decimal LabourCostFactory { get; set; }
        public decimal FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal LabourCostFactoryIncludingOverhead { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string AnalysisUser { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSewingIEDCommandHandler : IRequestHandler<UpdateSewingIEDCommand, Response<int>>
    {
        private readonly ISewingIEDRepository _repository;
        public UpdateSewingIEDCommandHandler(ISewingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSewingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingIED Not Found.");

            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.Buyer = command.Buyer;
            entity.StyleRef = command.StyleRef;
            entity.ProductGroup = command.ProductGroup;
            entity.SubCategory = command.SubCategory;
            entity.Description = command.Description;
            entity.AllowedTime = command.AllowedTime;
            entity.FactoryTime = command.FactoryTime;
            entity.LabourCostOp = command.LabourCostOp;
            entity.LabourCostFactory = command.LabourCostFactory;
            entity.FactoryOverheadAgainstLabourPercent = command.FactoryOverheadAgainstLabourPercent;
            entity.LabourCostFactoryIncludingOverhead = command.LabourCostFactoryIncludingOverhead;
            entity.Comment = command.Comment;
            entity.AnalysisDate = command.AnalysisDate;
            entity.AnalysisUser = command.AnalysisUser;
            entity.Status = command.Status;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
