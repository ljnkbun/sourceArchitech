using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Exports
{
    public class UpdateExportCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ExportStatus? Status { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public EntityState? EntityState { get; set; }
        public virtual ICollection<UpdateExportArticleCommand> ExportArticles { get; set; }
    }

    public class UpdateExportEntityCommandHandler : IRequestHandler<UpdateExportCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportRepository _repository;

        public UpdateExportEntityCommandHandler(IMapper mapper,
            IExportRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateExportCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportByIdAsync(command.Id);
            if (entity == null) return new($"ExportEntity Not Found.");
            entity.Status = command.Status;
            entity.Note = command.Note;
            entity.Name = command.Name;

            var dbArticles = entity.ExportArticles;
            var dbDetails = entity.ExportArticles.SelectMany(x => x.ExportDetails);
            var newDetails = command.ExportArticles.SelectMany(x => x.ExportDetails);
            entity.ExportArticles = null;

            // Article
            var newArticleModifieds = command.ExportArticles.Where(x => x.EntityState == EntityState.Modified);
            var dbArticleModifieds = dbArticles.Where(x => newArticleModifieds.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateExportArticleCommand, ExportArticle>(newArticleModifieds.First(c => c.Id == x.Id), x));
            var newArticleDeleteds = command.ExportArticles.Where(x => x.EntityState == EntityState.Deleted).Select(x => _mapper.Map<ExportArticle>(x));
            var dbArticleDeleteds = dbArticles.Where(x => newArticleDeleteds.Any(c => c.Id == x.Id));

            // Detail
            var newDetailModifieds = newDetails.Where(x => x.EntityState == EntityState.Modified);
            var dbDetailModifieds = dbDetails.Where(x => newDetailModifieds.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateExportDetailCommand, ExportDetail>(newDetailModifieds.First(c => c.Id == x.Id), x));


            var newDetailDeleteds = newDetails.Where(x => x.EntityState == EntityState.Deleted).Select(x => _mapper.Map<ExportDetail>(x));
            var dbDetailDeleteds = dbDetails.Where(x => newDetailDeleteds.Any(c => c.Id == x.Id));

            var newDetailAddeds = newDetails.Where(x => x.EntityState == EntityState.Added).Select(x => _mapper.Map<ExportDetail>(x)).ToList();

            await _repository.UpdateExportAsync(entity, dbArticleModifieds, dbArticleDeleteds, newDetailAddeds, dbDetailModifieds, dbDetailDeleteds);
            return new Response<int>(entity.Id);
        }
    }
}
