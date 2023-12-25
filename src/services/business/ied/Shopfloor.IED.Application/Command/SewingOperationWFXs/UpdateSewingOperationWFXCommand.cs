using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationWFXs
{
    public class UpdateSewingOperationWFXCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string Buyer { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal FactoryTime { get; set; }
        public decimal LabourCostOp { get; set; }
        public decimal LabourCostFactory { get; set; }
        public decimal FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal LabourCostFactoryIncludingOverhead { get; set; }
        public Status Status { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSewingOperationWFXCommandHandler : IRequestHandler<UpdateSewingOperationWFXCommand, Response<int>>
    {
        private readonly ISewingOperationWFXRepository _repository;
        public UpdateSewingOperationWFXCommandHandler(ISewingOperationWFXRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSewingOperationWFXCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingOperationWFX Not Found.");

            entity.WFXProcessCode = command.WFXProcessCode;
            entity.WFXProcessName = command.WFXProcessName;
            entity.Buyer = command.Buyer;
            entity.ProductGroup = command.ProductGroup;
            entity.ProductSubCategory = command.ProductSubCategory;
            entity.ArticleId = command.ArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.Description = command.Description;
            entity.Comments = command.Comments;
            entity.SMV = command.SMV;
            entity.AllowedTime = command.AllowedTime;
            entity.FactoryTime = command.FactoryTime;
            entity.LabourCostOp = command.LabourCostOp;
            entity.LabourCostFactory = command.LabourCostFactory;
            entity.FactoryOverheadAgainstLabourPercent = command.FactoryOverheadAgainstLabourPercent;
            entity.LabourCostFactoryIncludingOverhead = command.LabourCostFactoryIncludingOverhead;
            entity.Status = command.Status;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
