using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Exports
{
    public class UpdateExportCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ExportStatus? Status { get; set; }
        public string Note { get; set; }
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
            var entity = await _repository.GetExportByIdAsync(command.Id) ?? throw new ApiException($"ExportEntity Not Found.");
            entity.Status = command.Status;
            entity.Note = command.Note;

            var oldArticles = entity.ExportArticles;
            var oldDetails = entity.ExportArticles.SelectMany(x => x.ExportDetails);
            var newDetails = command.ExportArticles.SelectMany(x => x.ExportDetails);
            entity.ExportArticles = _mapper.Map<ICollection<ExportArticle>>(command.ExportArticles);
            var deleteArticles = oldArticles.Where(x => !command.ExportArticles.Select(o => o.Id).Contains(x.Id));
            var deleteDetails = oldDetails.Where(x => !newDetails.Select(o => o.Id).Contains(x.Id));

            foreach (var article in deleteArticles) article.Export = null;
            foreach (var detail in deleteDetails) detail.ExportArticle = null;

            await _repository.UpdateExportAsync(entity, deleteArticles, deleteDetails);
            return new Response<int>(entity.Id);
        }
    }
}
