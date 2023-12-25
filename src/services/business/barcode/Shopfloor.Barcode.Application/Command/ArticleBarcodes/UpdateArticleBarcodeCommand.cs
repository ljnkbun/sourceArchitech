using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class UpdateArticleBarcodeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PreLocationId { get; set; }
    }
    public class UpdateArticleBarcodeCommandHandler : IRequestHandler<UpdateArticleBarcodeCommand, Response<int>>
    {
        private readonly IArticleBarcodeRepository _repository;
        public UpdateArticleBarcodeCommandHandler(IArticleBarcodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateArticleBarcodeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ArticleBarcode Not Found.");
            entity.Barcode = command.Barcode;
            entity.ArticleName = command.ArticleName;
            entity.ArticleCode = command.ArticleCode;
            entity.Quantity = command.Quantity;
            entity.RemainQuantity = command.RemainQuantity;
            entity.Unit = command.Unit;
            entity.Shade = command.Shade;
            entity.OC = command.OC;
            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.NumberOfCone = command.NumberOfCone;
            entity.WeightPerCone = command.WeightPerCone;
            entity.Location = command.Location;
            entity.Note = command.Note;
            entity.CurrentLocationId = command.CurrentLocationId;
            entity.PreLocationId = command.PreLocationId;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
