using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class MergeArticleBarcodeCommand : IRequest<Response<int[]>>
    {
        public string Ids { get; set; }
    }

    public class MergeArticleBarcodeCommandHandler : IRequestHandler<MergeArticleBarcodeCommand, Response<int[]>>
    {
        private readonly IArticleBarcodeRepository _repository;

        public MergeArticleBarcodeCommandHandler(
            IArticleBarcodeRepository repository
            )
        {
            _repository = repository;
        }

        public async Task<Response<int[]>> Handle(MergeArticleBarcodeCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Ids)) throw new ApiException($"ArticleBarcode Not Found.");
            var ids = request.Ids.Split(",").Select(int.Parse).ToList();

            var entities = await _repository.GetByIdsAsync(ids);
            await _repository.MergeImportBarcodeDetail(entities);

            return new Response<int[]>(ids.ToArray());
        }
    }
}
