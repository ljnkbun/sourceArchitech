using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportArticles
{
    public class UpdateExportArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string FromSite { get; set; }
        public string Buyer { get; set; }
        public string SummaryOC { get; set; }
        public string DeliveryOC { get; set; }
        public string LotNo { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }
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
            var entity = await _repository.GetExportArticleByIdAsync(command.Id) ?? throw new ApiException($"ExportArticleEntity Not Found.");
            entity.Status = command.Status;
            entity.Quantity = command.Quantity;
            entity.UOM = command.UOM;
            entity.Note = command.Note;
            entity.LotNo = command.LotNo;
            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.FromSite = command.FromSite;
            entity.Buyer = command.Buyer;

            var oldDetails = entity.ExportDetails;
            entity.ExportDetails = _mapper.Map<ICollection<ExportDetail>>(command.ExportDetails);
            var deleteDetails = oldDetails.Where(x => !command.ExportDetails.Select(o => o.Id).Contains(x.Id));

            foreach (var detail in deleteDetails) detail.ExportArticle = null;

            await _repository.UpdateExportArticleAsync(entity, deleteDetails);

            return new Response<int>(entity.Id);
        }
    }
}
