using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shopfloor.Barcode.Application.Command.ImportTransferToSiteSyns
{
    public class UpdateImportTransferToSiteSyncCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? Qty { get; set; }
        public string UOM { get; set; }
        public string StoringUOM { get; set; }
        public string GDNNo { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }

    }

    public class UpdateImportTransferToSiteSyncCommandHandler : IRequestHandler<UpdateImportTransferToSiteSyncCommand, Response<int>>
    {
        private readonly IImportTransferToSiteSyncRepository _repository;

        public UpdateImportTransferToSiteSyncCommandHandler(IImportTransferToSiteSyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateImportTransferToSiteSyncCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ImportTransferToSiteSync Not Found.(Id:{command.Id})");
            entity.ArticleName = command.ArticleName;
            entity.ArticleCode = command.ArticleCode;
            entity.Color = command.Color;
            entity.UOM = command.UOM;
            entity.Size = command.Size;
            entity.Qty = command.Qty;
            entity.UOM = command.UOM;
            entity.StoringUOM = command.StoringUOM;
            entity.GDNNo = command.GDNNo;
            entity.FromSite = command.FromSite;
            entity.ToSite = command.ToSite;
            entity.OC = command.OC;
            entity.LotNo = command.LotNo;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
