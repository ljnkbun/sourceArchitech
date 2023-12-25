using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportArticles
{
    public class UpdateImportArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string GDNNumber { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string SupplierName { get; set; }
        public string OrderRefNum { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public string UOM { get; set; }
        public decimal? Units { get; set; }
        public string OCNum { get; set; }
        public ICollection<UpdateImportDetailCommand> ImportDetails { get; set; }
        public int ImportId { get; set; }
        public  EntityState EntityState { get; set; }
        public ImportType? Type { get; set; }
    }

    public class UpdateImportArticleCommandHandler : IRequestHandler<UpdateImportArticleCommand, Response<int>>
    {
        private readonly IImportArticleRepository _repository;
        private readonly IImportDetailRepository _repositoryImportDetail;
        private readonly IMapper _mapper;
        public UpdateImportArticleCommandHandler(IImportArticleRepository repository,  IMapper mapper, IImportDetailRepository repositoryImportDetail)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryImportDetail = repositoryImportDetail;
        }

        public async Task<Response<int>> Handle(UpdateImportArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetImportArticleByIdAsync(command.Id) ?? throw new ApiException($"ImportArticle Not Found.(Id:{command.Id}).");
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.GDNNumber = command.GDNNumber;
            entity.FromSite = command.FromSite;
            entity.ToSite = command.ToSite;
            entity.SupplierName = command.SupplierName;
            entity.OrderRefNum = command.OrderRefNum;
            entity.ColorCode = command.ColorCode;
            entity.ColorName = command.ColorName;
            entity.UOM = command.UOM;
            entity.Units = command.Units;
            entity.SizeCode = command.SizeCode;
            entity.OCNum = command.OCNum;

            entity.ImportDetails = null;
            var dbDetails = entity.ImportDetails;
            var newDetails = command.ImportDetails;
            // Detail
            var newDetailModifieds = newDetails.Where(x => x.EntityState == EntityState.Modified);
            var dbDetailModifieds = dbDetails.Where(x => newDetailModifieds.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateImportDetailCommand, ImportDetail>(newDetailModifieds.First(c => c.Id == x.Id), x));
            var newDetailDeleteds = newDetails.Where(x => x.EntityState == EntityState.Deleted).Select(x => _mapper.Map<ImportDetail>(x));
            var dbDetailDeleteds = dbDetails.Where(x => newDetailDeleteds.Any(c => c.Id == x.Id));

            var newDetailAddeds = newDetails.Where(x => x.EntityState == EntityState.Added && command.Type == ImportType.ImportPO).Select(x => _mapper.Map<ImportDetail>(x)).ToList();
            if (newDetailAddeds.Any())
            {
                var barcodes = await _repositoryImportDetail.GenBarCode(newDetailAddeds.FirstOrDefault()?.UOM, newDetailAddeds);
                if (!barcodes.Any()) throw new ApiException($"Error Generate Barcode");
            }
            
            await _repository.UpdateImportArticleAsync(entity, newDetailAddeds, dbDetailModifieds, dbDetailDeleteds);
            return new Response<int>(entity.Id);
        }
    }
}
