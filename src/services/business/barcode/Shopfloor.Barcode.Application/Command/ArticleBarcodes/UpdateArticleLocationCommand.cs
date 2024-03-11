using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.BarcodeLocations
{
    public class UpdateArticleLocationCommand : IRequest<Response<int>>
    {
        public UpdateBarcodeLocationCommand UpdateBarcodeLocationCommand { get; set; }
    }
    public class UpdateArticleLocationCommandHandler : IRequestHandler<UpdateArticleLocationCommand, Response<int>>
    {
        private readonly IArticleBarcodeRepository _repositoryArticleBarcode;
        private readonly IMapper _mapper;

        public UpdateArticleLocationCommandHandler(IMapper mapper, IArticleBarcodeRepository repository
            )
        {
            _mapper = mapper;
            _repositoryArticleBarcode = repository;
        }
        public async Task<Response<int>> Handle(UpdateArticleLocationCommand command, CancellationToken cancellationToken)
        {
            int articleBarcodeId = command.UpdateBarcodeLocationCommand.ArticleBarcodeId;
            var entity = await _repositoryArticleBarcode.GetByIdAsync(articleBarcodeId);
            if (entity == null) return new($"ArticleBarcode Not Found.(Id:{articleBarcodeId})");
            var oldLocationId = entity.CurrentLocationId;
            entity.PreLocationId = oldLocationId;
            entity.CurrentLocationId = command.UpdateBarcodeLocationCommand.LocationId;
            var barcodeLocationEntity = _mapper.Map<BarcodeLocation>(command.UpdateBarcodeLocationCommand);
            await _repositoryArticleBarcode.UpdateArticleBarcodeLocationAsync(entity, barcodeLocationEntity);
            return new Response<int>(entity.Id);
        }
    }
}
