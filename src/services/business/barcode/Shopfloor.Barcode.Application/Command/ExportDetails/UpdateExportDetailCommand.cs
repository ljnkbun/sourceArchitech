using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class UpdateExportDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }

        public string Name { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public int? ExportArticleId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string OC { get; set; }
        public string UOM { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string No { get; set; }
        public string Barcode { get; set; }
        public string ParentBarcode { get; set; }
        public string OCRefNum { get; set; }
        public string Location { get; set; }
        public string LotNo { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public decimal? RemainQuantity { get; set; }
        public decimal? WeightPerCone { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? Quantity { get; set; }
        public string Note { get; set; }
        public EntityState? EntityState { get;  set; }
    }

    public class UpdateExportDetailEntityCommandHandler : IRequestHandler<UpdateExportDetailCommand, Response<int>>
    {
        private readonly IExportDetailRepository _repository;

        public UpdateExportDetailEntityCommandHandler(IExportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateExportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ExportDetail Not Found.");
            entity.Status = command.Status;
            entity.Name = command.Name;
            entity.UOM = command.UOM;
            entity.Shade = command.Shade;
            entity.OC = command.OC;
            entity.Location = command.Location;
            entity.LotNo = command.LotNo;
            entity.Quantity = command.Quantity;
            entity.RemainQuantity = command.RemainQuantity;
            entity.NumberOfCone = command.NumberOfCone;
            entity.WeightPerCone = command.WeightPerCone;
            entity.WareHouse = command.WareHouse;
            entity.Quantity = command.Quantity;
            entity.WeightPerCone = command.WeightPerCone;
            entity.BuyerStyleRef = command.BuyerStyleRef;
            entity.ColorCode = command.ColorCode;
            entity.FPPOOCNUm = command.FPPOOCNUm;
            entity.No = command.No;
            entity.InternalShade = command.InternalShade;
            entity.LocationId = command.LocationId;
            entity.SizeCode = command.SizeCode;
            entity.RemainQuantity = command.RemainQuantity;
            entity.Note = command.Note;
            entity.ArticleBarcode.CurrentLocationId = command.LocationId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
