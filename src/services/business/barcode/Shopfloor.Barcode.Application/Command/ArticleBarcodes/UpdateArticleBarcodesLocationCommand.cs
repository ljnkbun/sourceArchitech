using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.BarcodeLocations
{
    public class UpdateArticleBarcodesLocationCommand : IRequest<Response<bool>>
    {
        public string Ids { get; set; }
        public int LocationId { get; set; }
    }
    public class UpdateArticleBarcodesLocationCommandHandler : IRequestHandler<UpdateArticleBarcodesLocationCommand, Response<bool>>
    {
        private readonly IArticleBarcodeRepository _repositoryArticleBarcode;
        private readonly IMapper _mapper;

        public UpdateArticleBarcodesLocationCommandHandler(IMapper mapper, IArticleBarcodeRepository repository
            )
        {
            _mapper = mapper;
            _repositoryArticleBarcode = repository;
        }
        public async Task<Response<bool>> Handle(UpdateArticleBarcodesLocationCommand command, CancellationToken cancellationToken)
        {
            var ids = command.Ids.Split(',').Select(x => int.Parse(x));

            var entities = await _repositoryArticleBarcode.GetByIdsAsync(ids.ToList());
            if (entities == null || !entities.Any()) return new($"ArticleBarcode Not Found.");

            var newBarcodeLocations = new List<BarcodeLocation>();
            foreach (var entity in entities)
            {
                var oldLocationId = entity.CurrentLocationId;
                entity.PreLocationId = oldLocationId;
                entity.CurrentLocationId = command.LocationId;

                newBarcodeLocations.Add(new()
                {
                    ArticleBarcodeId = entity.Id,
                    LocationId = command.LocationId
                });
            }

            var rs = await _repositoryArticleBarcode.UpdateArticleBarcodesLocationAsync(entities, newBarcodeLocations);
            return new Response<bool>(rs);
        }
    }
}
