using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class UpdateImportCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ImportStatus? Status { get; set; }
        public ImportType? Type { get; set; }
        public ICollection<UpdateImportArticleCommand> ImportArticles { get; set; }

    }
    public class UpdateImportCommandHandler : IRequestHandler<UpdateImportCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IImportRepository _repositoryImport;
        private readonly IImportDetailRepository _repositoryImportDetail;
        private readonly ILocationRepository _locationRepository;
        public UpdateImportCommandHandler(IMapper mapper, ILogger<UpdateImportCommand> logger,
            IImportRepository repositoryImport, IImportDetailRepository repositoryImportDetail, ILocationRepository locationRepository)
        {
            _repositoryImport = repositoryImport;
            _mapper = mapper;
            _repositoryImportDetail = repositoryImportDetail;
            _locationRepository = locationRepository;
        }

        public async Task<Response<int>> Handle(UpdateImportCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repositoryImport.GetImportByIdAsync(request.Id) ?? throw new ApiException($"Import Not Found.(Id:{request.Id})");
            entity.Status = request.Status;
            entity.Name = request.Name;
            entity.Note = request.Note;
            entity.Code = request.Code;
            var dbArticles = entity.ImportArticles;
            var dbDetails = entity.ImportArticles.SelectMany(x => x.ImportDetails);
            var newDetails = request.ImportArticles.SelectMany(x => x.ImportDetails);
            entity.ImportArticles = null;

            // Article
            var newArticleModifieds = request.ImportArticles.Where(x => x.EntityState == EntityState.Modified);
            var dbArticleModifieds = dbArticles.Where(x => newArticleModifieds.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateImportArticleCommand, ImportArticle>(newArticleModifieds.First(c => c.Id == x.Id), x));
            var newArticleDeleteds = request.ImportArticles.Where(x => x.EntityState == EntityState.Deleted).Select(x => _mapper.Map<ImportArticle>(x));
            var dbArticleDeleteds = dbArticles.Where(x => newArticleDeleteds.Any(c => c.Id == x.Id));

            // Detail
            var newDetailModifieds = newDetails.Where(x => x.EntityState == EntityState.Modified);
            var dbDetailModifieds = dbDetails.Where(x => newDetailModifieds.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateImportDetailCommand, ImportDetail>(newDetailModifieds.First(c => c.Id == x.Id), x));


            var newDetailDeleteds = newDetails.Where(x => x.EntityState == EntityState.Deleted).Select(x => _mapper.Map<ImportDetail>(x));
            var dbDetailDeleteds = dbDetails.Where(x => newDetailDeleteds.Any(c => c.Id == x.Id));

            var newDetailAddeds = newDetails.Where(x => x.EntityState == EntityState.Added && request.Type == ImportType.ImportPO).Select(x => _mapper.Map<ImportDetail>(x)).ToList();
            if (newDetailAddeds.Any())
            {
                var barcodes = await _repositoryImportDetail.GenBarCode(newDetailAddeds.FirstOrDefault()?.UOM, newDetailAddeds);
                if (!barcodes.Any()) throw new ApiException($"Error Generate Barcode");
            }

           
            await _repositoryImport.UpdateImportAsync(entity, dbArticleModifieds, dbArticleDeleteds, newDetailAddeds, dbDetailModifieds, dbDetailDeleteds);
            return new Response<int>(entity.Id);
        }
    }
}
