using MediatR;
using NPOI.Util;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class SplitArticleBarcodeCommand : IRequest<Response<int[]>>
    {
        public int Id { get; set; }
        public ICollection<SplitDetailModel> SplitDetailModels { get; set; }
    }

    public class SplitArticleBarcodeCommandHandler : IRequestHandler<SplitArticleBarcodeCommand, Response<int[]>>
    {
        private readonly IArticleBarcodeRepository _repository;

        public SplitArticleBarcodeCommandHandler(
            IArticleBarcodeRepository repository
            )
        {
            _repository = repository;
        }

        public async Task<Response<int[]>> Handle(SplitArticleBarcodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return new($"ArticleBarcode Not Found.");

            if (entity.Category == nameof(CategoryType.Yarns))
            {
                if (request.SplitDetailModels.Any(x => x.NumberOfCone == null || x.NumberOfCone == 0 || x.WeightPerCone == null || x.WeightPerCone == 0))
                    return new($"NumberOfCone and WeightPerCone must greater than 0");
            }

            var articleBarcodes = new List<ArticleBarcode>();
            foreach (var model in request.SplitDetailModels)
            {
                var articleBarcode = entity.Copy();
                articleBarcode.Id = 0;
                articleBarcode.ExportDetails = null;
                articleBarcode.ImportDetails = null;
                articleBarcode.Quantity = model.Quantity;
                articleBarcode.RemainQuantity = model.Quantity;
                articleBarcode.NumberOfCone = model.NumberOfCone;
                articleBarcode.WeightPerCone = model.WeightPerCone;

                entity.RemainQuantity -= model.Quantity;
                entity.NumberOfCone -= model.NumberOfCone;
                entity.WeightPerCone -= model.WeightPerCone;

                articleBarcodes.Add(articleBarcode);
            }

            if (entity.RemainQuantity < articleBarcodes.Sum(x => x.Quantity)) return new($"Out of Quantity can split");
            var rs = await _repository.SplitImportBarcodeDetail(entity, articleBarcodes);
            if (entity.RemainQuantity > 0)
            {
                rs = (new int[] { entity.Id }).Concat(rs).ToArray();
            }
            return new Response<int[]>(rs);
        }

    }
}
