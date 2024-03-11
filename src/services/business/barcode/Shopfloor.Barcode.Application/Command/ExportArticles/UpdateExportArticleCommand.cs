using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportArticles
{
    public class UpdateExportArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public int ExportId { get; set; }
        public string GDINum { get; set; }
        public string OrderRefNum { get; set; }
        public ExportTypes? GDIType { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string FromSite { get; set; }
        public string Buyer { get; set; }
        public string SummaryOC { get; set; }
        public string DeliveryOC { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }
        public EntityState? EntityState { get; set; }
        public ICollection<UpdateExportDetailCommand> ExportDetails { get; set; }
    }

    public class UpdateExportArticleEntityCommandHandler : IRequestHandler<UpdateExportArticleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportArticleRepository _repository;

        public UpdateExportArticleEntityCommandHandler(IMapper mapper, IExportArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateExportArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportArticleByIdAsync(command.Id);
            if (entity == null) return new($"ExportArticleEntity Not Found.");
            entity.Status = command.Status;
            entity.Name = command.Name;
            entity.Quantity = command.Quantity;
            entity.UOM = command.UOM;
            entity.Note = command.Note;
            entity.LocationId = command.LocationId;
            entity.ColorCode = command.ColorCode;
            entity.SizeCode = command.SizeCode;
            entity.FromSite = command.FromSite;
            entity.Buyer = command.Buyer;

            entity.ExportDetails = null;
            var dbDetails = entity.ExportDetails;
            var newDetails = command.ExportDetails;
            // Detail
            var newDetailModifieds = newDetails.Where(x => x.EntityState == EntityState.Modified);
            var dbDetailModifieds = dbDetails.Where(x => newDetailModifieds.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateExportDetailCommand, ExportDetail>(newDetailModifieds.First(c => c.Id == x.Id), x));
            var newDetailDeleteds = newDetails.Where(x => x.EntityState == EntityState.Deleted).Select(x => _mapper.Map<ExportDetail>(x));
            var dbDetailDeleteds = dbDetails.Where(x => newDetailDeleteds.Any(c => c.Id == x.Id));

            var newDetailAddeds = newDetails.Where(x => x.EntityState == EntityState.Added).Select(x => _mapper.Map<ExportDetail>(x)).ToList();
            await _repository.UpdateExportArticleAsync(entity, newDetailAddeds, dbDetailModifieds, dbDetailDeleteds);
            return new Response<int>(entity.Id);
        }
    }
}
