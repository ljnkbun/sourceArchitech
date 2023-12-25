using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class SplitArticleBarcodeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ICollection<SplitDetailModel> SplitDetailModels { get; set; }
    }

    public class SplitArticleBarcodeCommandHandler : IRequestHandler<SplitArticleBarcodeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleBarcodeRepository _repository;

        public SplitArticleBarcodeCommandHandler(IMapper mapper,
            IArticleBarcodeRepository repository
            )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SplitArticleBarcodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id) ?? throw new ApiException($"ArticleBarcode Not Found.");

            var articleBarcodes = _mapper.Map<List<ArticleBarcode>>(request.SplitDetailModels);
            if (entity.RemainQuantity < articleBarcodes.Sum(x => x.Quantity)) throw new ApiException($"Out of Quantity can split");
            await _repository.SplitImportBarcodeDetail(entity, articleBarcodes);
            return new Response<int>(entity.Id);
        }

    }
}
