using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORs
{
    public class UpdatePORCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? WfxOCId { get; set; }
        public string OCNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? WfxPORId { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public int? DivisionId { get; set; }
        public int? WfxArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public int? BOMId { get; set; }
        public string BOMNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PORStatus? Status { get; set; }
        public OCStatus? OCStatus { get; set; }
        public string Type { get; set; }
        public bool IsAllocated { get; set; }
        public string ProcessName { get; set; }
        public int? ProcessId { get; set; }
        public bool IsActive { get; set; }
        public string UOM { get; set; }
        public int? OrderId { get; set; }
        public string JobOrderNo { get; set; }
    }
    public class UpdatePORCommandHandler : IRequestHandler<UpdatePORCommand, Response<int>>
    {
        private readonly IPORRepository _repository;
        public UpdatePORCommandHandler(IPORRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdatePORCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"POR Not Found.");

            entity.PORNo = command.PORNo;
            entity.Status = command.Status;
            entity.RemainingQuantity = command.RemainingQuantity;
            entity.Quantity = command.Quantity;
            entity.ArticleName = command.ArticleName;
            entity.ArticleCode = command.ArticleCode;
            entity.Category = command.Category;
            entity.SubCategory = command.SubCategory;
            entity.Buyer = command.Buyer;
            entity.ProductGroup = command.ProductGroup;
            entity.OCNo = command.OCNo;
            entity.OCStatus = command.OCStatus;
            entity.DeliveryDate = command.DeliveryDate;
            entity.BOMId = command.BOMId;
            entity.BOMNo = command.BOMNo;
            entity.Type = command.Type;
            entity.DivisionName = command.DivisionName;
            entity.DivisionId = command.DivisionId;
            entity.WfxOCId = command.WfxOCId;
            entity.WfxPORId = command.WfxPORId;
            entity.ProcessId = command.ProcessId;
            entity.ProcessName = command.ProcessName;
            entity.IsAllocated = command.IsAllocated;
            entity.IsActive = command.IsActive;
            entity.UOM = command.UOM;
            entity.OrderId = command.OrderId;
            entity.JobOrderNo = command.JobOrderNo;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
