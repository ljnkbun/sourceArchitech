using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class MergeArticleBarcodeCommand : IRequest<Response<int>>
    {
        public string Ids { get; set; }
    }

    public class MergeArticleBarcodeCommandHandler : IRequestHandler<MergeArticleBarcodeCommand, Response<int>>
    {
        private readonly IArticleBarcodeRepository _repository;

        public MergeArticleBarcodeCommandHandler(
            IArticleBarcodeRepository repository
            )
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(MergeArticleBarcodeCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Ids)) return new($"ArticleBarcode Not Found.");
            var ids = request.Ids.Split(",").Select(int.Parse).ToList();

            var entities = await _repository.GetByIdsAsync(ids);
            var articleCodes = entities.Select(e => e.ArticleCode).Distinct();
            if( articleCodes.Count()>1) return new($"Cant merge Barcode from any Article");
            var mergedEntity = await _repository.MergeImportBarcodeDetail(entities);

            return new Response<int>(mergedEntity.Id);
        }
    }
}
